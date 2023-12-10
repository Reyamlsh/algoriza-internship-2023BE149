using Core.Domain;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Web.Models
{
    public class SQLPatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        public bool Delete(int id)
        {
            Patient pat = _context.Patients.Find(id);
            if (pat != null)
            {
                _context.Patients.Remove(pat);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients;
        }

        public Patient GetByID(int id)
        {
            return _context.Patients.Find(id);
        }

        public bool Insert(Patient entity)
        {
            if (entity != null)
            {
                _context.Patients.Add(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public int NumOfPatients()
        {
            return _context.Patients.Count();
        }

        public bool Update(Patient entity)
        {
            if (entity != null)
            {
                var patient = _context.Patients.Attach(entity);
                patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return false;
        }
    }
}
