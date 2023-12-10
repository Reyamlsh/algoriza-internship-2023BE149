using Core.Domain;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseEntityService<T> : IBaseEntityService<T> where T : BaseEntity
    {
        public IRepository<T> _repository;

        public BaseEntityService()
        {
        }

        public BaseEntityService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetByID(int ID)
        {
            return _repository.GetByID(ID);
        }

        public bool Insert(T entity)
        {
            
            if( _repository.Insert(entity))
            {
                _repository.SaveChanges();
                return true;
            }
                
            return false;
        }

        public bool Update(T entity)
        {
            if (_repository.Update(entity))
            {
                _repository.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (_repository.Delete(_repository.GetByID(id)))
            {
                _repository.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
