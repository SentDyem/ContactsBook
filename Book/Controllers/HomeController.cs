using Book.Hubs;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        ContactContext db = new ContactContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddContact()
        {
            return RedirectToAction("Create");
        }
        public ActionResult Contacts()
        {
            return View(db.Contacts);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
           SendMessage("Добавлен новый контакт!");
            return RedirectToAction("Contacts");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Contact b = db.Contacts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact b = db.Contacts.Find(id);

            db.Contacts.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Contacts");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
        }

    }
}