#region
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
#endregion
namespace QuizMaster.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize("Admin, User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializing a new instance of <see cref="UserController"/>
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="mapper"></param>
        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UserDto userDto)
        {
            try
            {
                //mapping from UserDto to UserRegistrationRequest
                var userRegistrationRequest = _mapper.Map<UserRegistrationRequest>(userDto);

                var user = await _userService.UpdateUserAsync(userRegistrationRequest);

                if(user is not null)
                {
                    return Ok(new { Message = "User updated successfully" });
                }
                else
                {
                    return BadRequest("Failed to update user, check the provided data and try again");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the user, UserDto: {userDto}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                var userToBeDeletedRequest = _mapper.Map<UserRegistrationRequest>(id);

                var userDeleted = await _userService.DeleteUserAsync(userToBeDeletedRequest);

                if (userDeleted is not null)
                {
                    //User successfully deleted
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the user: {ex.Message}", ex);
                
               return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" });
            }
        }

    }
}
