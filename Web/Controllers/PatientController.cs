using Core.Domain;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PatientController
    {
        private readonly IPatientService _patientrepo;
        private readonly IDoctorService _doctorrepo;
        private readonly IAppointmentService _appointrepo;
        private readonly IWorkingDateAndTimeService _workrepo;
        private readonly IDiscountService _discountrepo;


        public PatientController(IPatientService patientrepo, IAppointmentService appointrepo, IWorkingDateAndTimeService workrepo, IDiscountService discountrepo)
        {
            _patientrepo = patientrepo;
            _appointrepo = appointrepo;
            _workrepo = workrepo;
            _discountrepo = discountrepo;
        }

        public IEnumerable<Appointment> GetAllBookingsOfPatient(int PatientID)
        {
            IEnumerable<Appointment> apps = _appointrepo.GetAll();
            IEnumerable<Appointment> resultapps = new List<Appointment>();

            foreach (Appointment appointment in apps)
            {
                if (appointment.patient.ID == PatientID)
                {
                    resultapps.Append(appointment);
                }
            }

            return resultapps;
        }

        public bool CancelBooking(int ID)
        {
            Appointment app = _appointrepo.GetByID(ID);
            if (app != null) 
            {
                app.status = AppointmentStatus.Canceled;

                return true;
            }
            return false;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctorrepo.GetAll();
        }

        public IEnumerable<Doctor> GetAllDoctorsWithTime(int id, string? coupon)
        {
            IEnumerable<Doctor> docs = _doctorrepo.GetAll();

            IEnumerable<Doctor> docsWithTimings = new List<Doctor>();

            foreach (Doctor doc in docs) 
            {
                if(doc.workingHours.Contains(_workrepo.GetByID(id)) || doc.discounts.Contains(_discountrepo.GetDiscountbyCode(coupon)))
                {
                    docsWithTimings.Append(doc);
                }
            }

            return docsWithTimings;
        }

        

    }
}
