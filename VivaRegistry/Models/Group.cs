using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaRegistry.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int ApplicationId { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }
    }
}