using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class CompleteOrderController : BaseNVController
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            decimal totalMoney = 0;
            var orders = db.Orders.Where(c => c.status.Equals("4")).ToList();
            totalMoney = Total(orders);

            ViewBag.totalMoney = totalMoney;

            return View(orders);
        }

        public decimal Total(List<Order> items)
        {
            var total = items.Sum(s => decimal.Parse(s.total));
            return (decimal)total;
        }
    }
}