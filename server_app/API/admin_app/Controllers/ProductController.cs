using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class ProductController : BaseNVController
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            setViewBagCate();
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase image, Product product)
        {
            if (ModelState.IsValid)
            {
                var check = db.Products.Where(s => s.name_product.ToUpper().Trim().Equals(product.name_product.ToUpper().Trim().ToString())).FirstOrDefault();
                if (check == null)
                {
                    Guid g = Guid.NewGuid();
                    product.id_product= g.ToString();
                    product.name_product= CultureInfo.CurrentCulture.TextInfo.ToTitleCase(product.name_product.Trim().ToLower());

                    if (image != null)
                    {
                        var allowedExtensions = new[] {".Jpg", ".png", ".jpg", "jpeg"};
                        var fileName = Path.GetFileName(image.FileName);
                        var ext = Path.GetExtension(image.FileName);
                        if (allowedExtensions.Contains(ext))
                        {  
                            string name = Path.GetFileNameWithoutExtension(fileName);
                            string  physicalPath = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                            image.SaveAs(physicalPath);
                            string base64string;

                            using (Image images = Image.FromFile(physicalPath))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    images.Save(m, images.RawFormat);
                                    byte[] imageBytes = m.ToArray();
                                    base64string = Convert.ToBase64String(imageBytes);

                                }
                            }
                            product.image = base64string;

                        }
                        else
                        {
                            ViewBag.Error = "Hình ảnh sai định dạng";
                            setViewBagCate();
                            return View();
                        }
                    }
                    else product.image = "https://jollibee.com.vn/uploads/dish/d1834d87116836-2mingggin.png";



                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index", "product");
                }
                else
                {
                    ViewBag.Error = "Tên sản phẩm đã tồn tại";
                    setViewBagCate();
                    return View();
                }
            }

            setViewBagCate();
            return View();
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            var model = db.Products.Where(c => c.id_product.Equals(id)).FirstOrDefault();
            setViewBagCate();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase image, string id, Product product)
        {
            if (ModelState.IsValid)
            {
                var check = db.Products.Where(s => s.name_product.ToUpper().Trim().Equals(product.name_product.ToUpper().Trim().ToString()) && s.id_product.Equals(id) == false).FirstOrDefault();
                if (check == null)
                {
                    var updateItem = db.Products.Find(id);
                    updateItem.name_product = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(product.name_product.Trim().ToLower());
                    updateItem.price_product = product.price_product;
                    updateItem.id_category = product.id_category;
                    updateItem.describe = product.describe;
                    

                    if (image != null)
                    {
                        var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                        var fileName = Path.GetFileName(image.FileName);
                        var ext = Path.GetExtension(image.FileName);
                        if (allowedExtensions.Contains(ext))
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName);
                            string physicalPath = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                            image.SaveAs(physicalPath);
                            string base64string;

                            using (Image images = Image.FromFile(physicalPath))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    images.Save(m, images.RawFormat);
                                    byte[] imageBytes = m.ToArray();
                                     base64string = Convert.ToBase64String(imageBytes);
                                }
                            }
                            updateItem.image = base64string;
                        }
                        else
                        {
                            ViewBag.Error = "Hình ảnh sai định dạng";
                            setViewBagCate();
                            return View();
                        }
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index", "product");
                }
                else
                {
                    ViewBag.Error = "Tên sản phẩm đã tồn tại";
                    setViewBagCate();
                    return View(product);
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            var item = db.Products.Find(id);
            db.Products.Remove(item);
            db.SaveChanges();

            return Redirect("/product");
        }

        public void setViewBagCate()
        {
            List<Category> categories = db.Categories.ToList();
            ViewBag.category = new SelectList(categories, "id_category", "name");
        }

    }
}