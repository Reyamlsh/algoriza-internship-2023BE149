using Core.Domain;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Web.Models
{
    public class SQLSpecializationService : ISpecializationService
    {
        private readonly ApplicationDbContext _context;

        public SQLSpecializationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            Specialization specialization = _context.Specializations.Find(id);
            if (specialization != null)
            {
                _context.Specializations.Remove(specialization);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Specialization> GetAll()
        {
            return _context.Specializations;
        }

        public Specialization GetByID(int id)
        {
            return _context.Specializations.Find(id);
        }

        public bool Insert(Specialization entity)
        {
            if (entity != null)
            {
                _context.Specializations.Add(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<(string, int)> Top5Specializations()
        {
            IEnumerable<Doctor> docs = _context.Doctors;
            IEnumerable<Specialization> specs = _context.Specializations;
            IEnumerable<Doctor> top5 = new List<Doctor>();

            for (int i = 0; i < docs.Count(); i++)
            {
                foreach (var spec in specs)
                {
                    if (docs.ElementAt(i).specialization.ID == spec.ID)
                    {
                        if (docs.ElementAt(i).requests.Count() > docs.ElementAt(i + 1).requests.Count())
                        {
                            top5.Append(docs.ElementAt(i));
                        }
                    }
                }

            }

            var top5specializations = top5.OrderByDescending(d => d.requests.Count()).Take(5)
                .Select(d => (d.specialization.name, d.requests.Count()));

            return top5specializations;
        }

        public bool Update(Specialization entity)
        {
            if (entity != null)
            {
                var spec = _context.Specializations.Attach(entity);
                spec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return false;
        }

      
    }
}
