using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class CustomerController : BaseNVController
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            var cus = db.Users.Where(c => c.id_permission.Equals("04859514654")).ToList();
            return View(cus);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.Where(s => s.email.ToUpper().Trim().Equals(user.email.ToUpper().Trim().ToString())
                           || s.username.ToUpper().Trim().Equals(user.username.ToUpper().Trim().ToString())).FirstOrDefault();
                if (check == null)
                {
                    Guid g = Guid.NewGuid();
                    user.id_user = g.ToString();
                    user.fullname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.fullname.Trim().ToLower());
                    user.id_permission = "04859514654";

                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ViewBag.Error = "Email hoặc Username đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var user = db.Users.Where(c => c.id_user.Equals(id)).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(string id, User user)
        {
            var updateItem = db.Users.Find(id);

            user.fullname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.fullname.Trim().ToLower());

            updateItem.fullname = user.fullname;
            if (user.password != null)
            {
                updateItem.password = user.password;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "User");
        }
        public ActionResult Delete(string id)
        {
            var item = db.Users.Find(id);
            db.Users.Remove(item);
            db.SaveChanges();

            return Redirect("/customer");
        }
        

    }
}