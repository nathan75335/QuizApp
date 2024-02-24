#region
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
#endregion
namespace QuizMaster.BusinessLogic.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository,
        IMapper mapper, ILogger<UserService> logger, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<UserDto> AddUserAsync(UserRegistrationRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is not null)
        {
            _logger.LogError("A User with this email {email} already exist", request.Email);
            throw new AlreadyExistsException("This user exists already");
        }

        var userWithRole = SetUserRole(_mapper.Map<User>(request));
        var userAdded = await _userRepository.AddUserAsync(userWithRole);

        return _mapper.Map<UserDto>(userAdded);
    }

    public async Task<UserDto> DeleteUserAsync(UserRegistrationRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            _logger.LogError("This user with {email} does not exist", request.Email);

            throw new NotFoundException("This user does not exist");
        }

        var deletedUser = await _userRepository.DeleteUserAsync(_mapper.Map<User>(request));

        return _mapper.Map<UserDto>(deletedUser);
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user is null)
        {
            _logger.LogError("This user with the id provided does not exist");
            throw new NotFoundException("There is no user with that Id");
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<string> LoginAsync(UserLoginRequest userLogin)
    {
        var user = await _userRepository.GetUserByEmailAsync(userLogin.Email);
        if (!IsValidUser(user, userLogin))
        {
            _logger.LogError("There is no user with that email");
            throw new Unauthorized("Wrong email, please try again or sign up");
        }

        return GenerateToken(user);
    }

    public async Task<UserDto> UpdateUserAsync(UserRegistrationRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            _logger.LogError("There is no user with that email");
            throw new NotFoundException("There is no user to update with that email");
        }

        var updatedUser = await _userRepository.UpdateUserAsync(_mapper.Map<User>(request));

        return _mapper.Map<UserDto>(updatedUser);
    }

    private User SetUserRole(User user)
    {
        user.RoleId = -2;

        return user;
    }
    private bool IsValidUser(User user, UserLoginRequest userLogin)
    {
        if (user is null)
        {
            throw new NotFoundException("The user was not found");
        }

        if (user.Password != userLogin.Password)
        {
            return false;
        }

        return true;
    }

    private string GenerateToken(User user)
    {
        var claimsIdentity = new ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.Name)
        });

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:key"])), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
