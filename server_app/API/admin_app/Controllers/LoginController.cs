using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValidField("email"))
            {
                var check = db.Users.Where(s => s.email == user.email && s.password == user.password).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.Error = "Email hoặc mật khẩu không đúng";
                    return View();
                }
                else
                {
                    if(check.Permission.permission1.Equals("Nhân Viên"))
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        Session["id"] = check.id_user;
                        Session["role"] = check.Permission.permission1;
                        Session["fullname"] = check.fullname;
                        return RedirectToAction("Index", "Customer");
                    }else if(check.Permission.permission1.Equals("Admin"))
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        Session["id"] = check.id_user;
                        Session["role"] = check.Permission.permission1;
                        Session["fullname"] = check.fullname;
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ViewBag.Error = "Bạn không có quyền đăng nhập";
                        return View();
                    }

                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult MenuCategories()
        {
            List<Menu> modelList = new List<Menu>();

            Menu model = new Menu();

            if (Session["role"].Equals("Nhân Viên"))
            {
                model.Item = "Customer";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "Product";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "Category";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "Order";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "ConfirmOrder";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "Delivery";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "ConfirmDelivery";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "CompleteOrder";
                model.Permission = "Nhân viên";
                modelList.Add(model);

                model = new Menu();
                model.Item = "CancelOrder";
                model.Permission = "Nhân viên";
                modelList.Add(model);
            }
            else if (Session["role"].Equals("Admin"))
            {
                model = new Menu();
                model.Item = "User";
                model.Permission = "Admin";
                modelList.Add(model);

                model = new Menu();
                model.Item = "Permission";
                model.Permission = "Admin";
                modelList.Add(model);
            }



            return PartialView(modelList);
        }
    }
}