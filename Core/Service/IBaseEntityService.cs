using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IBaseEntityService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);

    }
}
