using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IDoctorService : IBaseEntityService<Doctor>
    {
        int NumOfDoctors();
        public IEnumerable<(string, string?, Specialization, int)> Top10Doctors();

        void AddWorkingHours(int id, Day d, TimeSpan from, TimeSpan to, double price);
    }
}
