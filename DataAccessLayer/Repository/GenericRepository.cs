
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public List<T> GetList()
        {
            return _object.ToList();
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
