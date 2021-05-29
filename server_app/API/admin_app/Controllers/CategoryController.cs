using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class CategoryController : BaseNVController
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var check = db.Categories.Where(s => s.name.ToUpper().Trim().Equals(category.name.ToUpper().Trim().ToString())).FirstOrDefault();
                if (check == null)
                {
                    Guid g = Guid.NewGuid();
                    category.id_category = g.ToString();
                    category.name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(category.name.Trim().ToLower());

                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ViewBag.Error = "Loại đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var model = db.Categories.Where(c => c.id_category.Equals(id)).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string id,Category category)
        {
            if (ModelState.IsValid)
            {
                var check = db.Categories.Where(s => s.name.ToUpper().Trim().Equals(category.name.ToUpper().Trim().ToString())&& !s.id_category.Equals(id)).FirstOrDefault();
                if (check == null)
                {
                    var updateItem = db.Categories.Find(id);

                    updateItem.name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(category.name.Trim().ToLower());
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ViewBag.Error = "Loại đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            var item = db.Categories.Find(id);
            db.Categories.Remove(item);
            db.SaveChanges();

            return Redirect("/category");
        }
    }
}