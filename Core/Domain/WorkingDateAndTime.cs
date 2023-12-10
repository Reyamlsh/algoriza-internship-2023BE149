using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public enum Day
    {
        Saturday, Sunday, Monday, Tuesday,
        Wednesday, Thursday, Friday
    }

    //[Table("WorkingDateAndTime")]
    public class WorkingDateAndTime : BaseEntity
    {
        [Required]
        public Day day { get; set; }

        [Required]
        public TimeSpan timeFrom { get; set; }

        [Required]
        public TimeSpan timeTo { get; set; }

        public double price { get; set; }

    }
}
