using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository;

namespace Service
{
    public class DoctorService : BaseEntityService<Doctor>, IDoctorService
    {
        public DoctorService(IRepository<Doctor> repository) : base(repository)
        {
        }

        public void AddWorkingHours(int id, Day d, TimeSpan from, TimeSpan to, double pr)
        {
            Doctor doc = _repository.GetByID(id);
            if (doc != null) 
            {
                WorkingDateAndTime work = new WorkingDateAndTime
                {
                    day = d,
                    timeFrom = from,
                    timeTo = to,
                    price = pr
                };

                doc.workingHours.Add(work);
            }

           
        }

        public int NumOfDoctors()
        {
            return _repository.GetAll().Count();
        }

        public IEnumerable<(string, string?, Specialization, int)> Top10Doctors()
        {
            IEnumerable<Doctor> docs = _repository.GetAll();
            IEnumerable<Appointment> apps = (IEnumerable<Appointment>)_repository.GetAll();
            IEnumerable<Doctor> top10 = new List<Doctor>();

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
    }
}
