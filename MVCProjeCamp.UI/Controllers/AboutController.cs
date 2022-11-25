using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.UI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EFAboutDAL());

        public ActionResult Index()
        {
            var values = _aboutManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aboutManager.TInsert(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }
    }
}