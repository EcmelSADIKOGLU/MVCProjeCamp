
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        Context context = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _object.ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
           return _object.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            
            context.SaveChanges();
        }
    }
}
