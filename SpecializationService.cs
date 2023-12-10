using Core.Domain;
using Core.Repository;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SpecializationService : BaseEntityService<Specialization>, ISpecializationService
    {
        public SpecializationService(IRepository<Specialization> repository) : base(repository)
        {
        }

        public IEnumerable<(string, int)> Top5Specializations()
        {
            IEnumerable<Doctor> docs = (IEnumerable<Doctor>)_repository.GetAll();
            IEnumerable<Specialization> specs = _repository.GetAll();
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
    }
}
