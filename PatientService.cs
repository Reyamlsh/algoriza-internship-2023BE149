using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Core.Service;
using Repository;

namespace Service
{
    public class PatientService : BaseEntityService<Patient>, IPatientService
    {
        public PatientService(IRepository<Patient> repository) : base(repository)
        {
        }

        public int NumOfPatients()
        {
            return _repository.GetAll().Count();
        }
    }
}
