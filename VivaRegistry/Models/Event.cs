using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaRegistry.Models
{
    public class Event
    {
        [Key]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        [Display(Name = "Generation Date")]
        public DateTime EventGenerationDate { get; set; }
        [Display(Name = "Application ID")]
        public int AppId { get; set; }
        [Display(Name = "Log Level")]
        public int LogId { get; set; }
        [ForeignKey("AppId")]
        public virtual Application Application { get; set; }
        [ForeignKey("LogId")]
        public virtual LogLevel LogLevel { get; set; }
        public virtual ICollection<GroupEvent> GroupEvent { get; set; }
    }
}