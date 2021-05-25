using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class OrderController : BaseNVController
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            decimal totalMoney = 0;
            var orders = db.Orders.ToList();
            totalMoney = Total(orders);

            ViewBag.totalMoney = totalMoney;

            return View(orders);
        }

        public decimal Total(List<Order> items)
        {
            var total = items.Sum(s => decimal.Parse(s.total));
            return (decimal)total;
        }

        public ActionResult Detail(string id)
        {
            ViewBag.Order = new Order();
            ViewBag.Order = db.Orders.Where(c => c.id_history.Equals(id)).FirstOrDefault();
            var detail = db.Detail_Order.Where(c => c.id_history.Equals(id)).ToList();
            return View(detail);
        }
    }
}