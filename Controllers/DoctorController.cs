using Core.Domain;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DoctorController
    {
        private readonly IDoctorService _doctorrepo;
        private readonly IAppointmentService _appointrepo;
        private readonly IWorkingDateAndTimeService _workrepo;

        public DoctorController(IDoctorService doctorrepo, IAppointmentService appointrepo, IWorkingDateAndTimeService workrepo)
        {
            _doctorrepo = doctorrepo;
            _appointrepo = appointrepo;
            _workrepo = workrepo;
        }

        public IEnumerable<Appointment> GetAllAppointmentsOfDoctor(int DoctorID)
        {
            IEnumerable<Appointment> apps = _appointrepo.GetAll();
            IEnumerable<Appointment> resultapps = new List<Appointment>();

            foreach (Appointment appointment in apps)
            {
                if (appointment.doctor.ID == DoctorID)
                {
                    resultapps.Append(appointment);
                }
            }

            return resultapps;
        }

        public bool ConfirmCheckUp(int ID)
        {
            Appointment app = _appointrepo.GetByID(ID);
            app.status = AppointmentStatus.Completed;
            return true;
        }

        public bool AddWorkingHours(WorkingDateAndTime entity, int ID)
        {
            if (_workrepo.Insert(entity))
            {
                _doctorrepo.GetByID(ID).workingHours.Add(entity);
                return true;
            }

            return false;
        }
        public bool UpdateWorkingHours(WorkingDateAndTime entity, int ID)
        {
            IEnumerable<Appointment> allApointments = GetAllAppointmentsOfDoctor(ID);

            foreach (Appointment appointment in allApointments)
            {
                if (entity.ID == appointment.appointmentTime.ID && appointment.status != AppointmentStatus.Pending)
                {
                    _workrepo.Update(entity);
                    return true;
                }
            }

            return false;
        }
        public bool DeleteWorkingHours(int id, int DoctorID)
        {
            IEnumerable<Appointment> allApointments = GetAllAppointmentsOfDoctor(DoctorID);

            foreach (Appointment appointment in allApointments)
            {
                if (id == appointment.appointmentTime.ID && appointment.status != AppointmentStatus.Pending)
                {
                    _workrepo.Delete(id);
                    return true;
                }
            }

            return false;
        }
    }
}
