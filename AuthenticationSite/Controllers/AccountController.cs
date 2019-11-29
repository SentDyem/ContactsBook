using AuthenticationSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationSite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            //ПРОВЕРКА МОДЕЛИ НА ВАЛИДНОСТЬ
            if (ModelState.IsValid)
            {
                // ЕСЛИ ВАЛИДАЦИЯ УСПЕШНА, ТО ПОИСК ПО ЛОГИНУ И ПАРОЛЮ В БД
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Login && u.Password == model.Password);
                }
                //ЕСЛИ ЮЗЕР НАДЙЕН
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                //ЕСЛИ ЮЗЕР НЕ НАЙДЕН
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем не существует");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login);
                }
                if (user == null)
                {
                    //НОВЫЙ ЮЗЕР
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { Email = model.Email, Login = model.Login, Password = model.Password, Age = model.Age });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    //ЕСЛИ ЮЗЕР УСПЕШНО СОЗДАН
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка! Пользователь с таким логином уже существует");
                }
                
            }
            return View(model);
        }
    }
}