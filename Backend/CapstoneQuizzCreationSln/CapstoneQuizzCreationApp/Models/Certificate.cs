using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneQuizzCreationApp.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int SubmissionId { get; set; }
        public int MaxObtainedScore { get; set; }
        public DateTime ProvidedDate { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("TestId")]
        public CertificationTest CertificationTest { get; set; }
        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

    }
}
