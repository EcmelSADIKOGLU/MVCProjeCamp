using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.UI.Controllers
{
    public class WriterController : Controller
    {
        
        WriterManager WriterManager = new WriterManager(new EFWriterDAL());
        WriterValidatior validator = new WriterValidatior();
        public ActionResult Index()
        {
            var values = WriterManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {

            ValidationResult result = validator.Validate(writer);

            if (result.IsValid)
            {
                WriterManager.TInsert(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
            
        }
        public ActionResult DeleteWriter(int id)
        {
            var value = WriterManager.TGetByID(id);
            WriterManager.TDelete(value);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var value = WriterManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = validator.Validate(writer);

            if (result.IsValid)
            {
                WriterManager.TUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

    }
}