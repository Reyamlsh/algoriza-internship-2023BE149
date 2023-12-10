using Azure.Core;
using Core.Domain;
using Core.Repository;
using Core.Service;
using Repository;
using System.Collections.Generic;

namespace Web.Models
{
    public class SQLDoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        public SQLDoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddWorkingHours(int id, Day d, TimeSpan from, TimeSpan to)
        {
            Doctor doc = _context.Doctors.Find(id);

            if (doc != null)
            {
                WorkingDateAndTime work = new WorkingDateAndTime
                {
                    day = d,
                    timeFrom = from,
                    timeTo = to
                };

                doc.workingHours.Add(work);
            }
        }

        public void AddWorkingHours(int id, Day d, TimeSpan from, TimeSpan to, double price)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            Doctor doc = _context.Doctors.Find(id);
            if(doc != null) 
            {
                _context.Doctors.Remove(doc);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors;
        }

        public Doctor GetByID(int id)
        {
            return _context.Doctors.Find(id);
        }

        public bool Insert(Doctor entity)
        {
            if(entity != null)
            {
                _context.Doctors.Add(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public int NumOfDoctors()
        {
            return _context.Doctors.Count();
        }
        //{image,fullName,specialize,#requests}
        public IEnumerable<(string, string?, Specialization, int)> Top10Doctors()
        {
            IEnumerable<Doctor> docs = _context.Doctors;
            IEnumerable<Appointment> apps = _context.Appointments;
            IEnumerable <Doctor> top10 = new List<Doctor>();
            
            for (int i = 0; i < docs.Count(); i++)
            {
                foreach (var app in apps)
                {
                    if (app.doctor.ID == docs.ElementAt(i).ID)
                    {
                        if (docs.ElementAt(i).requests.Count() > docs.ElementAt(i + 1).requests.Count())
                        {
                            top10.Append(docs.ElementAt(i));
                        }
                    }
                }

            }

            var top10doctors = top10.OrderByDescending(d => d.requests.Count()).Take(10)
                .Select(d => (d.firstName + " " + d.lastName, d.image, d.specialization, d.requests.Count()));

            return top10doctors;
        }

        public bool Update(Doctor entity)
        {
            if( entity != null) 
            { 
                var doctor = _context.Doctors.Attach(entity);
                doctor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return false;
        }
    }
}
