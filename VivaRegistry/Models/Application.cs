using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VivaRegistry.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        [MaxLength(80)]
        [Display(Name = "Application Key")]
        public string ApplicationKey { get; set; }
        [MaxLength]
        [Display(Name = "Application Name")]
        public string ApplicationName { get; set; }
        [Display(Name = "Application Email")]
        public string ApplicationEmail { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}