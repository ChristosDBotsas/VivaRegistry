using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VivaRegistry.Models
{
    public class LogLevel
    {
        public int LogLevelId { get; set; }
        [Display(Name = "Level")]
        public string LogLevelName { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}