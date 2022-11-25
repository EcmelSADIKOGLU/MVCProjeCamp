using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.UI.Controllers
{
    public class ContentController : Controller
    {
        ContentManager _contentManager = new ContentManager(new EFContentDAL());
        HeadingManager _headingManager = new HeadingManager(new EFHeadingDAL());


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var values = _contentManager.TGetList(x => x.HeadingID == id);
            ViewBag.heading = _headingManager.TGetByID(id).HeadingName;
            return View(values);
        }
    }
}