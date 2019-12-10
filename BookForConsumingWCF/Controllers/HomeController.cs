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
            BookServiceClient o = new BookServiceClient();
            List<Contact> li = o.Get().ToList();
            ViewBag.List = li;
            Response.AddHeader("Refresh", "5");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult Get()
        //{
        //    BookServiceClient o = new BookServiceClient();
        //    List<Contact> li = o.Get().ToList();
        //    ViewBag.List = li;
        //    return View();
        //}

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Contact cobj)
        {
            BookServiceClient o = new BookServiceClient();
            o.Insert(cobj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(Contact cobj)
        {
            BookServiceClient o = new BookServiceClient();
            o.Update(cobj);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            BookServiceClient o = new BookServiceClient();
            o.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}