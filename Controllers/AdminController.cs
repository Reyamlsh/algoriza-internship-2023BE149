using Core.Domain;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdminController
    {
        private readonly IDoctorService _doctorrepo;
        private readonly IPatientService _patientrepo;
        private readonly IAppointmentService _appointrepo;
        private readonly ISpecializationService _specrepo;
        private readonly IDiscountService _discountrepo;

        public AdminController(IDoctorService doctorrepo, IPatientService patientrepo, IAppointmentService appointrepo, ISpecializationService specrepo, IDiscountService discountrepo)
        {
            _doctorrepo = doctorrepo;
            _patientrepo = patientrepo;
            _appointrepo = appointrepo;
            _specrepo = specrepo;
            _discountrepo = discountrepo;
        }

        //Doctors
        public int GetNumOfDoctors()
        {
            return _doctorrepo.NumOfDoctors();
        }
        public  IEnumerable<(string, string?, Specialization, int)> GetTop10Doctors()
        {
            return _doctorrepo.Top10Doctors();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctorrepo.GetAll();
        }

        public Doctor GetDoctorByID(int id)
        {
            return _doctorrepo.GetByID(id);
        }

        public bool AddDoctor(Doctor entity)
        {
            if (_doctorrepo.Insert(entity))
                return true;
            return false;
        }
        public bool EditDoctor(Doctor entity)
        {
            if (_doctorrepo.Update(entity))
                return true;
            return false;
        }
        public bool DeleteDoctor(int id)
        {
            if (_doctorrepo.Delete(id))
                return true;
            return false;
        }

        public IEnumerable<(string, int)> GetTop5Specializations()
        {
            return _specrepo.Top5Specializations();
        }

        //Patients
        public int GetNumOfPatients()
        {
            return _patientrepo.NumOfPatients();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientrepo.GetAll();
        }

        public Patient GetPatientByID(int id)
        {
            return _patientrepo.GetByID(id);
        }

        //Appointments
        public Dictionary<string, int> GetNumOfRequests()
        {
             return _appointrepo.NumOfRequests();
        }
        public bool AddDiscount(Discount entity)
        {
            if (_discountrepo.Insert(entity))
                return true;
            return false;
        }
        public bool EditDiscount(Discount entity)
        {
            if (_discountrepo.Update(entity))
                return true;
            return false;
        }
        public bool DeleteDiscount(int id)
        {
            if (_discountrepo.Delete(id))
                return true;
            return false;
        }

        public bool DeactivateDiscount(int ID)
        {
            Discount disc = _discountrepo.GetByID(ID);
            disc.activationStatus = false;

            if (!disc.activationStatus)
                return true;
            return false;
        }

    }
}
