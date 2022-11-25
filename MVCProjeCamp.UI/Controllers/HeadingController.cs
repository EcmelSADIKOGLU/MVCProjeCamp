using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVCProjeCamp.UI.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager _headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager _writerManager = new WriterManager(new EFWriterDAL());
        


        public ActionResult Index()
        {
            var values = _headingManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in _categoryManager.TGetList() 
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            

            List<SelectListItem> writers = (from x in _writerManager.TGetList()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterName + " " + x.WriterSurname,
                                                Value = x.WriterID.ToString()
                                            }).ToList();

            ViewBag.categories = categories;
            ViewBag.writers = writers;


            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _headingManager.TInsert(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            var values = _headingManager.TGetByID(id);

            List<SelectListItem> categories = (from x in _categoryManager.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View(values);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.TUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult StatusFalse(int id)
        {
            var heading = _headingManager.TGetByID(id);
            _headingManager.ToggleStatus(heading);
            return RedirectToAction("Index");
        }

    }
}