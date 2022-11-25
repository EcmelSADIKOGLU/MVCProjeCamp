using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void TDelete(Writer entity)
        {
            _writerDAL.Delete(entity);
        }

        public Writer TGetByID(int id)
        {
            return _writerDAL.GetByID(id);
        }

        public List<Writer> TGetList()
        {
            return _writerDAL.GetList();
        }

        public List<Writer> TGetList(Expression<Func<Writer, bool>> filter)
        {
            return _writerDAL.GetList(filter);
        }

        public void TInsert(Writer entity)
        {
            _writerDAL.Insert(entity);
        }

        public void TUpdate(Writer entity)
        {
            _writerDAL.Update(entity);
        }
    }
}
