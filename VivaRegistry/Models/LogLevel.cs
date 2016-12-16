using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VivaRegistry.Models
{
    public class LogLevel
    {
        public int LogLevelId { get; set; }
        public string LogLevelName { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}