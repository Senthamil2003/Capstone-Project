using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneQuizzCreationApp.Models
{
    public class Submission
    {
        [Key] 
        public int SubmissionId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int TotalScore { get; set; }
        public double TimeTaken { get; set; }

        public int UserId { get; set; }
        public int TestId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("TestId")]
        public CertificationTest CertificationTest { get; set; }


    }
}
