using inventory_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventory_ManagementSystem.Controllers
{
    public class ProductController : Controller
    {
		Inventory_managementEntities db = new Inventory_managementEntities();
		// GET: Product
		public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x=>x.id).ToList();
            return View(list);    
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}