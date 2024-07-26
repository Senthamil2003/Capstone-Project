using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models.DTO.Folder;
using CapstoneQuizzCreationApp.Models.DTO.RequestDTO;
using CapstoneQuizzCreationApp.Models.DTO.ResponseDTO;
using CapstoneQuizzCreationApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneQuizzCreationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testservice;
        private readonly ILogger<TestController> _logger;   
        public TestController(ITestService testservice, ILogger<TestController> logger)
        {
            _testservice = testservice;
            _logger = logger;
        }
        [HttpGet("StartTest")]
        [ProducesResponseType(typeof(QuestionWithExpiryDate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<QuestionWithExpiryDate>> StartTest(int CertificateTestId ,int UserId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                QuestionWithExpiryDate result = await _testservice.StartTest(CertificateTestId, UserId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpGet("ResumeTest")]
        [ProducesResponseType(typeof(QuestionWithExpiryDate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<QuestionWithExpiryDate>> ResumeTest(int SubmissionId, int UserId)
        {
            try
            {
                _logger.LogInformation("Received a user login request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the login request.");
                    return BadRequest(ModelState);
                }

                QuestionWithExpiryDate result = await _testservice.ResumeTest(SubmissionId, UserId);
                _logger.LogInformation("User authenticated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user authentication: {ex.Message}");
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("SynchronizeTestData")]
        [ProducesResponseType(typeof(SuccessSynchronieDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SuccessSynchronieDTO>> Synchronize(List<SynchronousDataDTO> data)
        {
            try
            {
                _logger.LogInformation("Received a user registration request.");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for the registration request.");
                    return BadRequest(ModelState);
                }

                SuccessSynchronieDTO result = await _testservice.SynchronizeDb(data);
                _logger.LogInformation("User registered successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during user registration: {ex.Message}");
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }


    }
}
