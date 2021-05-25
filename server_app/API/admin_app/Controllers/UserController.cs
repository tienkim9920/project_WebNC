using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class UserController : BaseAdminController
    {
        // GET: User
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            var user = db.Users.ToList();
            return View(user);
        }

        public ActionResult Create()
        {
            setViewBagPer();
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

                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.Error = "Email hoặc Username đã tồn tại";
                    setViewBagPer();
                    return View();
                }
            }

            setViewBagPer();
            return View();
        }

        public ActionResult Edit(string id)
        {
            var user = db.Users.Where(c => c.id_user.Equals(id)).FirstOrDefault();
            setViewBagPer();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(string id,User user)
        {
            var updateItem = db.Users.Find(id);

            user.fullname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.fullname.Trim().ToLower());

            updateItem.fullname = user.fullname;
            updateItem.id_permission = user.id_permission;
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

            return Redirect("/user");
        }

        public void setViewBagPer()
        {
            List<Permission> permissions = db.Permissions.ToList();
            ViewBag.permission = new SelectList(permissions, "id_permission", "permission1");
        }
    }
}