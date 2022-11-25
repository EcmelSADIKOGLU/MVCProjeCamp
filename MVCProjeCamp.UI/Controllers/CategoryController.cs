using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MVCProjeCamp.UI.Controllers
{
    public class CategoryController : Controller
    {
        
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());

        [Authorize]
        public ActionResult Index()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult validationResult = categoryValidatior.Validate(category);

            if (validationResult.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.TInsert(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = categoryManager.TGetByID(id);
            categoryManager.TDelete(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = categoryManager.TGetByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            CategoryValidatior validatior = new CategoryValidatior();
            ValidationResult result = validatior.Validate(category);
            if (result.IsValid)
            {
                categoryManager.TUpdate(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View(category);


        }
    } 
}