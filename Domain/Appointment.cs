using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public enum AppointmentStatus
    {
        Pending, Completed, Canceled
    }

    //[Table("Appointment")]
    public class Appointment : BaseEntity
    {
        [ForeignKey("PatientID")]
        public Patient patient { get; set; }

        [ForeignKey("DoctorID")]
        public Doctor doctor { get; set; }

        public WorkingDateAndTime appointmentTime { get; set; }
        public AppointmentStatus status { get; set; }

        //[ForeignKey("DiscountID")]
        public Discount discount { get; set; }

    }
}
