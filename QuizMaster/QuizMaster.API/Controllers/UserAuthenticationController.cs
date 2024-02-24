using Microsoft.AspNetCore.Mvc;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;

namespace QuizMaster.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private ILogger<UserAuthenticationController> _logger;
        public UserAuthenticationController(IUserService userService,
            ILogger<UserAuthenticationController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("registration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
        {
                await _userService.AddUserAsync(userRegistrationRequest);

                return Ok(userRegistrationRequest);
           
        }

        /// <summary>
        /// Handles user login by validating hiscredentials, generating an authentication token, 
        /// and setting a secure cookie.
        /// </summary>
        /// <param name="userLoginRequest">The user credentials provided in the request body</param>
        /// <returns>
        ///     <list type="bullet">
        ///         <item>
        ///             <description>The HTTP 200 OK with a token in the response body if authentication is successful</description>
        ///         </item>
        ///         <item>
        ///             <description>The HTTP 401 Unauthorized with an error message if authentication fails</description>
        ///         </item>
        ///         <item>
        ///             <description>HTTP 500 Internal Server Error with an error message if an exception occurs during the process</description>
        ///         </item>
        ///     </list>
        /// </returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LogIn([FromBody] UserLoginRequest userLoginRequest)
        {
           
                //attempt user authentication and get the authentication token
                var token = await _userService.LoginAsync(userLoginRequest);

                // return HTTP 200 OK with the token in the response body
                return Ok(new { Token = token });
          

        }

        [HttpGet("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult LogOut()
        {
            try
            {
                //clearing the authentication token cookie
                Response.Cookies.Delete("token");

                return Ok(new { Message = "User succesfully logged out" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while processing user logout");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while processing the request");
            }

        }
    }
}
