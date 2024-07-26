namespace CapstoneQuizzCreationApp.Models.DTO.ResponseDTO
{
    public class QuestionWithExpiryDate
    {
        public DateTime TestEndTime { get; set; }
        public List<TestQuestionDTO> testQuestion {get; set; }
    }
}
