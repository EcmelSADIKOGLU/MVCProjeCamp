using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        List<T> GetList();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
