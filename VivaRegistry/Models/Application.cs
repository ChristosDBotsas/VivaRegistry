using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaRegistry.Models
{
    public class Application
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ApplicationId { get; set; }
        public int ApplicationKey { get; set; }
        [MaxLength]
        public string ApplicationName { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}