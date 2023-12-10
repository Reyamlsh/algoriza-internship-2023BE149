using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPatientService : IBaseEntityService<Patient>
    {
        int NumOfPatients();
    }
}
