using inventory_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventory_ManagementSystem.Controllers
{
    public class SaleController : Controller
	{
		Inventory_managementEntities db = new Inventory_managementEntities();

		// GET: Purchase
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult DisplaySale()
		{
			List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult SaleProduct()
		{
			List<string> list = db.Products.Select(x => x.product_name).ToList();
			ViewBag.product_name = new SelectList(list);
			return View();

		}
		[HttpPost]
		public ActionResult SaleProduct(Sale salee)
		{
			//sale.total_price = sale.unit_price * int.Parse(sale.Sale_pnty);

			Sale sale = db.Sales.Add(salee);
			db.SaveChanges();
			return RedirectToAction("DisplaySale");
		}
		[HttpGet]
		public ActionResult UpdateSaleProduct(int id)
		{


			Sale update = db.Sales.Where(x => x.id == id).SingleOrDefault();
			List<string> list = db.Products.Select(x => x.product_name).ToList();
			ViewBag.product_name = new SelectList(list);
			return View(update);
		}
		[HttpPost]
		public ActionResult UpdateSaleProduct(int id, Sale pur)
		{
			Sale p = db.Sales.Where(x=>x.id == id).SingleOrDefault();
			p.Sale_product = pur.Sale_product;
			p.Sale_date = pur.Sale_date;


			p.Sale_pnty = pur.Sale_pnty;
			//p.unit_price = pur.unit_price;
			//p.total_price = pur.total_price;
			//p.total_price = pur.unit_price * int.Parse(pur.Purchase_pnty);

			db.SaveChanges();

			return RedirectToAction("DisplaySale");



		}

		[HttpGet]
		public ActionResult DetailsSale(int id)
		{
			Sale pr = db.Sales.Where(model => model.id == id).SingleOrDefault();
			return View(pr);
		}

		[HttpGet]
		public ActionResult DeleteSale(int id)
		{

			Sale pr = db.Sales.Where(model => model.id == id).FirstOrDefault();
			return View(pr);
		}
		[HttpPost]
		public ActionResult DeleteSale(int id, Product pro)
		{
			Sale pr = db.Sales.Where(model => model.id == id).FirstOrDefault();
			db.Sales.Remove(pr);
			db.SaveChanges();
			return RedirectToAction("DisplaySale");
		}
	}
}