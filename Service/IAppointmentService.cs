using Core.Domain;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAppointmentService : IBaseEntityService<Appointment>
    {
        Dictionary<string, int> NumOfRequests();
        bool ConfirmCheckUp(int ID);
        //public IList<Appointment> GetAllDocAppointments(int ID);
        bool CancelAppointment(int ID);

    }
}
