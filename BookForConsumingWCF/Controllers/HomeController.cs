using BookForConsumingWCF.WCFServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookForConsumingWCF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetContacts");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetContacts(Contact obj)
        {
            BookServiceClient o = new BookServiceClient();
            List<Contact> li = o.GetContacts().ToList();
            ViewBag.List = li;
            return View();
        }

        [HttpGet]
        public ActionResult InsertContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertContact(Contact obj)
        {
            BookServiceClient o = new BookServiceClient();
            o.InsertContact(obj);
            return RedirectToAction("GetContacts");
        }

        [HttpGet]
        public ActionResult UpdateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact obj)
        {
            BookServiceClient o = new BookServiceClient();
            o.UpdateContact(obj);
            return RedirectToAction("GetContacts");
        }
        [HttpGet]
        public ActionResult DeleteContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteContact(int Id)
        {
            BookServiceClient o = new BookServiceClient();
            o.DeleteContact(Id);
            return RedirectToAction("GetContacts");
        }

    }
}