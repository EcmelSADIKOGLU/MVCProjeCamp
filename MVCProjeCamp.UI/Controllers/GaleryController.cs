using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.UI.Controllers
{
    public class GaleryController : Controller
    {
        ImageFileManager _imageFileManager = new ImageFileManager(new EFImageFileDAL());


        public ActionResult Index()
        {
            var values = _imageFileManager.TGetList();
            return View(values);
        }
    }
}