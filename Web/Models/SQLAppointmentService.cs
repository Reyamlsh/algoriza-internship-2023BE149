using Core.Domain;
using Core.Service;

namespace Web.Models
{
    public class SQLAppointmentService : IAppointmentService
    {
        public bool CancelAppointment(int ID)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmCheckUp(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Appointment entity)
        {
            throw new NotImplementedException();
        }


        public bool Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, int> IAppointmentService.NumOfRequests()
        {
            throw new NotImplementedException();
        }
    }
}
