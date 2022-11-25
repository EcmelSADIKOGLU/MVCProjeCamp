using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDAL;

        public HeadingManager(IHeadingDAL headingDAL)
        {
            _headingDAL = headingDAL;
        }

        public void ToggleStatus(Heading heading)
        {
            heading.HeadingStatus = !(heading.HeadingStatus);
            _headingDAL.Update(heading);
        }

        public void TDelete(Heading entity)
        {
            _headingDAL.Delete(entity);
        }

        public Heading TGetByID(int id)
        {
            return _headingDAL.GetByID(id);
        }

        public List<Heading> TGetList()
        {
            return _headingDAL.GetList();
        }

        public List<Heading> TGetList(Expression<Func<Heading, bool>> filter)
        {
            return _headingDAL.GetList(filter);
        }

        public void TInsert(Heading entity)
        {
            _headingDAL.Insert(entity);
        }

        public void TUpdate(Heading entity)
        {
            _headingDAL.Update(entity);
        }
    }
}
