namespace CapstoneQuizzCreationApp.Models.DTO.ResponseDTO
{
    public class QuestionWithExpiryDate
    {
        public DateTime TestEndTime { get; set; }
        public int SubmissionId { get; set; }
        public bool IsSubmited { get; set; } = false;   
        public List<TestQuestionDTO> testQuestion {get; set; }
    }
}
