using inventory_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventory_ManagementSystem.Controllers
{
    public class PurchaseController : Controller
	{
		Inventory_managementEntities db = new Inventory_managementEntities();

		// GET: Purchase
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult DisplayPurchase()
		{
			List<Purchase> list = db.Purchases.OrderByDescending(x => x.id).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult PurchaseProduct()
		{
			List<string> list=db.Products.Select(x=>x.product_name).ToList();
			ViewBag.product_name = new SelectList(list);
			return View();

		}
		[HttpPost]
		public ActionResult PurchaseProduct(Purchase pur)
		{
			pur.total_price = pur.unit_price * int.Parse(pur.Purchase_pnty);

			db.Purchases.Add(pur);
			db.SaveChanges();
			return RedirectToAction("DisplayPurchase");
		}
		[HttpGet]
		public ActionResult UpdatePurchaseProduct(int id)
		{
			
			
				Purchase update = db.Purchases.Where(x => x.id == id).SingleOrDefault();
			List<string>list=db.Products.Select(x=> x.product_name).ToList();
			ViewBag.product_name=new SelectList(list);
			return View(update);
			}
		[HttpPost]
		public ActionResult UpdatePurchaseProduct(int id ,Purchase pur)
		{
			Purchase p=db.Purchases.Where(x=> x.id == id).SingleOrDefault();
			p.Purchase_date = pur.Purchase_date;
			p.Purchase_product = pur.Purchase_product;
			p.Purchase_pnty = pur.Purchase_pnty;
			p.unit_price = pur.unit_price;
			p.total_price = pur.total_price;
			p.total_price = pur.unit_price * int.Parse(pur.Purchase_pnty);

			db.SaveChanges();
			
			return RedirectToAction("DisplayPurchase");


		
		}

		[HttpGet]
		public ActionResult DetailsPurchase(int id)
		{
			Purchase pr= db.Purchases.Where(model=>model.id == id).SingleOrDefault();
			return View(pr);
		}

		[HttpGet]
		public ActionResult DeletePurchase(int id)
		{

			Purchase purr = db.Purchases.Where(model => model.id == id).SingleOrDefault();
			return View(purr);
		}
		[HttpPost]
		public ActionResult DeletePurchase(int id, Purchase pro)
		{
			Purchase pr = db.Purchases.Where(model => model.id == id).FirstOrDefault();
			db.Purchases.Remove(pr);
			db.SaveChanges();
			return RedirectToAction("DisplayPurchase");
		}
	}
}