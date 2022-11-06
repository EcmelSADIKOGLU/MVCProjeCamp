using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVCProjeCamp.UI.Controllers
{
    public class StatisticController : Controller
    {
        //ICategoryDAL categoryDAL;
        //IHeadingDAL headingDAL;

        //public StatisticController(ICategoryDAL categoryDAL, IHeadingDAL headingDAL)
        //{
        //    this.categoryDAL = categoryDAL;
        //    this.headingDAL = headingDAL;
        //}
        Context context = new Context();

        public ActionResult Index()
        {
            var value1 = context.Categories.Where(x=>x.CategoryName == "Yazılım").Select(x => x.CategoryID).FirstOrDefault();
            ViewBag.v1 = context.Categories.ToList().Count();
            ViewBag.v2= context.Headings.Where(x => x.CategoryID == (value1)).ToList().Count();
            ViewBag.v3 = context.Writers.Where(x => x.WriterName.Contains("a")).ToList().Count();
            var value = context.Headings.GroupBy(s => s.CategoryID)
            .Select(s => new
            {
                Category = s.Key,
                Max = s.Count()
            }).OrderByDescending(x => x.Max).ToList();
            int id = value[0].Category;
            ViewBag.v4 = context.Categories.Where(x => x.CategoryID == id).FirstOrDefault().CategoryName;
            

            int statetrue = context.Categories.Where(x => x.CategoryStatus == true).Count();
            int statefalse = context.Categories.Where(x => x.CategoryStatus == false).Count();
            ViewBag.v5 = statetrue-statefalse;
            return View();
        }
    }
}