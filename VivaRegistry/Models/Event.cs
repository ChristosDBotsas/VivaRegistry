using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaRegistry.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public DateTime EventGenerationDate { get; set; }
        public Guid AppId { get; set; }
        public int LogId { get; set; }
        [ForeignKey("AppId")]
        public virtual Application Application { get; set; }
        [ForeignKey("LogId")]
        public virtual LogLevel LogLevel { get; set; }
    }
}