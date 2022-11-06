using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        List<T> GetList();
        List<T> GetList(Expression<Func<T,bool>> filter);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetByID(int id);
    }
}
