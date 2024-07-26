using CapstoneQuizzCreationApp.Models.DTO.RequestDTO;
using CapstoneQuizzCreationApp.Models.DTO.ResponseDTO;

namespace CapstoneQuizzCreationApp.Interfaces
{
    public interface ITestService
    {
        public Task<QuestionWithExpiryDate> StartTest(int certificationTestId, int UserId);
        public Task<QuestionWithExpiryDate> ResumeTest(int userId, int SubmissionId);
        public Task<SuccessSynchronieDTO> SynchronizeDb(List<SynchronousDataDTO> answers);

    }
}
