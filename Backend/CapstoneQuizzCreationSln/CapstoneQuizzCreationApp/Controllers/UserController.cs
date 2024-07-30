using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models;
using CapstoneQuizzCreationApp.Models.DTO.Folder;
using CapstoneQuizzCreationApp.Models.DTO.ResponseDTO;
using CapstoneQuizzCreationApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneQuizzCreationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService,
            ILogger<UserController> logger
         ) 
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet("AllTests")]
        [ProducesResponseType(typeof(List<AllTestsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<AllTestsDTO>>> GetAllTest( int UserId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                var result = await _userService.GetAllTestsWithUsers( UserId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpGet("History")]
        [ProducesResponseType(typeof(List<AllTestsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<AllTestsDTO>>> GetTestHistory(int UserId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                var result = await _userService.GetUserHistory(UserId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }

        [HttpPost("AddToFavourite")]
        [ProducesResponseType(typeof(UpdateFavouriteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UpdateFavouriteDTO>> AddFavourite(int UserId,int TestId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                var result = await _userService.AddToFavourate(UserId,TestId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPut("RemoveFromFavourite")]
        [ProducesResponseType(typeof(UpdateFavouriteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UpdateFavouriteDTO>> RemoveFavourite(int UserId, int FavouriteId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                var result = await _userService.RemoveFromFavourite(UserId,FavouriteId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpGet("GetMyFavoutites")]
        [ProducesResponseType(typeof(List<AllTestsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<AllTestsDTO>>> GetAllMyFavourites(int UserId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                var result = await _userService.GetMyFavourite(UserId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpGet("GetPopularTests")]
        [ProducesResponseType(typeof(List<AllTestsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<AllTestsDTO>>> GetPopularTests(int UserId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                var result = await _userService.GetPopularTests(UserId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
    }
   
}
   

