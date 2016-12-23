using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaRegistry.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        [MaxLength(80)]
        public string ApplicationKey { get; set; }
        [MaxLength]
        public string ApplicationName { get; set; }
        public string ApplicationEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}