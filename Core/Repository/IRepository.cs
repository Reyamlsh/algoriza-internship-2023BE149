using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByID(int ID);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        void SaveChanges();
    }
}
