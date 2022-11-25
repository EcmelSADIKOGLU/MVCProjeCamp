using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVCProjeCamp.UI.Controllers
{
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EFMessageDAL());
        MessageValidatior _messageValidatior = new MessageValidatior();


        ContactManager _contactManager = new ContactManager(new EFContactDAL());
        public ActionResult Inbox()

        {
            var values = _messageManager.TGetList(x => x.MessageReceiverMail == "admin@gmail.com" && x.MessageStatus == true);
            ViewBag.MessageCount = values.Count();

            ViewBag.ContactMessageCount = _contactManager.TGetList().Count();
            ViewBag.InboxMessageCount = _messageManager.TGetList(x => x.MessageReceiverMail == "admin@gmail.com").Count();
            ViewBag.SendboxMessageCount = _messageManager.TGetList(x => x.MessageSenderMail == "admin@gmail.com").Count();
            return View(values);
        }

        public ActionResult Sendbox()
        {
            var values = _messageManager.TGetList(x => x.MessageSenderMail == "admin@gmail.com" && x.MessageStatus == true);
            
            ViewBag.ContactMessageCount = _contactManager.TGetList().Count();
            ViewBag.InboxMessageCount = _messageManager.TGetList(x => x.MessageReceiverMail == "admin@gmail.com").Count();
            ViewBag.SendboxMessageCount = _messageManager.TGetList(x => x.MessageSenderMail == "admin@gmail.com").Count();

            return View(values);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var message = _messageManager.TGetByID(id);
            return View(message);
        }

        [HttpGet]
        public ActionResult WriteMessage()
        {

            ViewBag.ContactMessageCount = _contactManager.TGetList().Count();
            ViewBag.InboxMessageCount = _messageManager.TGetList(x => x.MessageReceiverMail == "admin@gmail.com").Count();
            ViewBag.SendboxMessageCount = _messageManager.TGetList(x => x.MessageSenderMail == "admin@gmail.com").Count();

            return View();
        }

        [HttpPost]
        public ActionResult WriteMessage(Message message)
        {
            ValidationResult result = _messageValidatior.Validate(message);
            if (result.IsValid)
            {
                message.MessageStatus = true;
                message.MessageDate = Convert.ToDateTime(DateTime.Now.ToString("dd MMM yyyy"));
                message.MessageSenderMail = "admin@gmail.com";
                _messageManager.TInsert(message);
                return RedirectToAction("Sendbox");
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

        public ActionResult TrashMessage(int id)
        {
            var message = _messageManager.TGetByID(id);
            message.MessageStatus = false;
            _messageManager.TUpdate(message);
            return RedirectToAction("Inbox");
        }

        public ActionResult TrashBox()
        {
            var values = _messageManager.TGetList(x=>x.MessageStatus == false);
            return View(values);
        }

    }
}