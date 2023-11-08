using inventory_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public ActionResult UpdateProduct(int id) { 
            Product update=db.Products.Where(x =>x.id==id).FirstOrDefault();
            return View(update);
        }
        [HttpPost]
		public ActionResult UpdateProduct(int id, Product pro)
		{
            if(ModelState.IsValid)
            {

			Product update = db.Products.Where(x => x.id == id).FirstOrDefault();
            update.product_name = pro.product_name;
            update.product_qnty = pro.product_qnty;
			
     


			db.SaveChanges();
			return RedirectToAction("DisplayProduct");
            }
                else { return View(); }
            

		}
        [HttpGet]
        public ActionResult ProductDetails (int id)
        {
            Product updt= db.Products.Where(model=>model.id==id).FirstOrDefault();
            return View(updt);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {

            Product pr=db.Products.Where(model=>model.id==id).FirstOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id,Product pro)
        {
            Product pr =db.Products.Where(model=>model.id == id).FirstOrDefault();
            db.Products.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }



}


}