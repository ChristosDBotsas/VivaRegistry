using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaRegistry.Models
{
    public class GroupEvent
    {
        [Key]
        [Column(Order = 1)]
        public int GroupId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int EventId { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}