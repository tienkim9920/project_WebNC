using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class PermissionController : BaseAdminController
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            var permission = db.Permissions.ToList();
            return View(permission);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                var check = db.Permissions.Where(s => s.permission1.ToUpper().Trim().Equals(permission.permission1.ToUpper().Trim().ToString())).FirstOrDefault();
                if (check == null)
                {
                    Guid g = Guid.NewGuid();
                    permission.id_permission = g.ToString();
                    permission.permission1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(permission.permission1.Trim().ToLower());

                    db.Permissions.Add(permission);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Permission");
                }
                else
                {
                    ViewBag.Error = "Quyền đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var model = db.Permissions.Where(c => c.id_permission.Equals(id)).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id, Permission permission)
        {
            if (ModelState.IsValid)
            {
                var check = db.Permissions.Where(s => s.permission1.ToUpper().Trim().Equals(permission.permission1.ToUpper().Trim().ToString()) && s.id_permission.Equals(id)==false).FirstOrDefault();
                if (check == null)
                {
                    var updateItem = db.Permissions.Find(id);

                    updateItem.permission1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(permission.permission1.Trim().ToLower());

                    db.SaveChanges();
                    return RedirectToAction("Index", "Permission");
                }
                else
                {
                    ViewBag.Error = "Quyền đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            var item = db.Permissions.Find(id);
            db.Permissions.Remove(item);
            db.SaveChanges();

            return Redirect("/permission");
        }
    }
}