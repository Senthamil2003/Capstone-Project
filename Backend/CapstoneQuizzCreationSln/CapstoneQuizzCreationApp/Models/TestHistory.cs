using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneQuizzCreationApp.Models
{
    public class TestHistory
    {
        [Key]
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public  int MaxObtainedScore { get; set; }
        public int CertificateId { get; set; }
        public bool IsPassed { get; set; }=false;

        public int LastSubmissionId { get; set; }
        public DateTime LatesttestEndTime { get; set; }
        [ForeignKey("UserId")]   
        public User User { get; set; }
        [ForeignKey("TestId")]
        public CertificationTest CertificationTest { get; set; }
        [ForeignKey("CertificateId")]
        public Certificate? Certificate { get; set; }
    }
}
