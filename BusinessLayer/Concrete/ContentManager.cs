using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDAL _contentDAL;

        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void TDelete(Content entity)
        {
            _contentDAL.Delete(entity);
        }

        public Content TGetByID(int id)
        {
            return _contentDAL.GetByID(id);
        }

        public List<Content> TGetList()
        {
            return _contentDAL.GetList();
        }

        public List<Content> TGetList(Expression<Func<Content, bool>> filter)
        {
            return _contentDAL.GetList(filter);
        }

        public void TInsert(Content entity)
        {
            _contentDAL.Insert(entity);
        }

        public void TUpdate(Content entity)
        {
            _contentDAL.Update(entity);

        }
    }
}
