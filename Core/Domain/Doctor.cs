using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    //[Table("Doctors")]
    public class Doctor : User
    {
        public List<WorkingDateAndTime> workingHours { get; set; }
        public List<Appointment> requests { get; set; }

        [Required]
        public Specialization specialization { get; set; }

        [Required]
        public string workAddress { get; set; }

        public List<Discount> discounts { get; set; }
    }
}
