using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    //[Table("Patients")]
    public class Patient : User
    {
        public List<Appointment> bookings { get; set; }
    }
}
