using System.ComponentModel.DataAnnotations;

namespace CapstoneQuizzCreationApp.Models
{
    public class CertificationTest
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public double TestTakenCount { get; set; }
        public int QuestionCount { get; set; }
        public int RetakeWaitDays { get; set; }
        public int TestDurationMinutes { get; set; }

    }
}
