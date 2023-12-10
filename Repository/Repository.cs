using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            this._entity = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }

        public T GetByID(int ID)
        {
            return _entity.FirstOrDefault(s => s.ID == ID);
        }

        public bool Insert(T entity)
        {
            if (entity != null)
            {
                _entity.Add(entity);
                return true;
            }

             return false;
        }

        public bool Update(T entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }

            return false;
        }

        public bool Delete(T entity)
        {
            if (entity != null)
            {
                _entity.Remove(entity);
                return true;
            }

            return false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
