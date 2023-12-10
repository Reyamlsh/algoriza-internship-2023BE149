using Core.Domain;
using Core.Repository;
using Core.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AppointmentService : BaseEntityService<Appointment>, IAppointmentService
    {
        public AppointmentService(IRepository<Appointment> repository) : base(repository)
        {
        }

        public bool CancelAppointment(int ID)
        {
            Appointment app = _repository.GetByID(ID);
            app.status = AppointmentStatus.Canceled;
            return true;
        }

        public bool ConfirmCheckUp(int ID)
        {
            Appointment app = _repository.GetByID(ID);
            app.status = AppointmentStatus.Completed;
            return true;
        }

        public Dictionary<string, int> NumOfRequests()
        {
            IEnumerable<Appointment> app = _repository.GetAll();
            Dictionary<string, int> result = new Dictionary<string, int>();

            int numOfAllRequests = app.Count();
            int numOfPendingRequests = 0;
            int numOfCompletedRequests = 0;
            int numOfCanceledRequests = 0;

            foreach (Appointment appointment in app) 
            {
                if(appointment.status == AppointmentStatus.Canceled)
                {
                    numOfCanceledRequests++;
                }

                if (appointment.status == AppointmentStatus.Pending)
                {
                    numOfPendingRequests++;
                }

                if (appointment.status == AppointmentStatus.Completed)
                {
                    numOfCompletedRequests++;
                }
            }

            result.Add("#Requests: ", numOfAllRequests);
            result.Add("#PendingRequests: ", numOfPendingRequests);
            result.Add("#CompletedRequests: ", numOfCompletedRequests);
            result.Add("#CanceledRequests: ", numOfCanceledRequests);

            return result;
        }
    }
}
