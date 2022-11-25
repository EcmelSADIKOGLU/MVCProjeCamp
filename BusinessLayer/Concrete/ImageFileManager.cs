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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDAL _imageFileDAL;

        public ImageFileManager(IImageFileDAL imageFileDAL)
        {
            _imageFileDAL = imageFileDAL;
        }

        public void TDelete(ImageFile entity)
        {
            _imageFileDAL.Delete(entity);
        }

        public ImageFile TGetByID(int id)
        {
            return _imageFileDAL.GetByID(id);
        }

        public List<ImageFile> TGetList()
        {
            return _imageFileDAL.GetList();
        }

        public List<ImageFile> TGetList(Expression<Func<ImageFile, bool>> filter)
        {
            return _imageFileDAL.GetList(filter);
        }

        public void TInsert(ImageFile entity)
        {
            _imageFileDAL.Insert(entity);
        }

        public void TUpdate(ImageFile entity)
        {
            _imageFileDAL.Update(entity);
        }
    }
}
