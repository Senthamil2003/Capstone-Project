using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneQuizzCreationApp.Models
{
    public class Favourite
    {
        [Key]
        public int FavouriteId { get; set; }    
        public int TestId { get; set; }
        public DateTime AddedDate { get; set; }

        [ForeignKey("TestId")]
        public CertificationTest CertificationTest { get; set; }
    }
}
