using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.UI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EFContactDAL());
        ContactValidatior contactValidatior = new ContactValidatior();

        MessageManager _messageManager = new MessageManager(new EFMessageDAL());
        public ActionResult Index()
        {
            var values = _contactManager.TGetList(x=>x.ContactStatus == true);
            
            ViewBag.ContactMessageCount = _contactManager.TGetList().Count();
            ViewBag.InboxMessageCount = _messageManager.TGetList(x => x.MessageReceiverMail == "admin@gmail.com").Count();
            ViewBag.SendboxMessageCount = _messageManager.TGetList(x => x.MessageSenderMail == "admin@gmail.com").Count();

            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var value = _contactManager.TGetByID(id);

            ViewBag.ContactMessageCount = _contactManager.TGetList().Count();
            ViewBag.InboxMessageCount = _messageManager.TGetList(x => x.MessageReceiverMail == "admin@gmail.com").Count();
            ViewBag.SendboxMessageCount = _messageManager.TGetList(x => x.MessageSenderMail == "admin@gmail.com").Count();
                
            return View(value);
        }

        public ActionResult TrashContact(int id)
        {
            var contact = _contactManager.TGetByID(id);
            contact.ContactStatus = false;
            _contactManager.TUpdate(contact);
            return RedirectToAction("Index");
        }

        public ActionResult TrashBox()
        {
            var values = _contactManager.TGetList(x=>x.ContactStatus == false);
            return View(values);
        }

        public PartialViewResult ContactSideBar()
        {
     
            return PartialView();
        }
    }
}