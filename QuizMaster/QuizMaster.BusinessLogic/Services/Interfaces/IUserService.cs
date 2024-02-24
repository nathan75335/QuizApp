using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;

namespace QuizMaster.BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> AddUserAsync(UserRegistrationRequest request);
    Task<UserDto> UpdateUserAsync(UserRegistrationRequest request);
    Task<UserDto> DeleteUserAsync(UserRegistrationRequest request);
    Task<UserDto> GetUserById(int id);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<string> LoginAsync(UserLoginRequest userLogin);
}
