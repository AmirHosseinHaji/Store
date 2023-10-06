using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using System.Diagnostics;

namespace Store.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private MyDBShopContext _db;
		public HomeController(MyDBShopContext db,ILogger<HomeController> logger)
		{
			_logger = logger;
			_db = db;
		}
		//صفحه اول سایت

		public ActionResult Index()
		{
			var list = _db.Kala.ToList();
			ViewData["count"]=list.Count;
			return View(list);
		}
		//ایجاد نوع کالا
		[Authorize]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Kala kala)
		{
			ViewData["ID"] = ViewData["ItemId"];
			_db.Kala.Add(kala);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		[Authorize]
		public ActionResult Edit(int id)
		{
			var index = _db.Kala.SingleOrDefault(c => c.KalaId == id);
			return View(index);
		}
		[HttpPost]
		public ActionResult Edit(Kala kala)
		{
			_db.Kala.Update(kala);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var rem = _db.Kala.Find(id);
			_db.Kala.Remove(rem);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult NewKala()
		{
			return View();
		}
		[HttpPost]
		public ActionResult NewKala(NewKala newKala)
		{
			_db.UserKala.Add(newKala);
			_db.SaveChanges();
			return RedirectToAction("NewKala");
		}

		public ActionResult Detail(int id)
		{
			var a = _db.Kala.Find(id);
			return View(a);
		}

		
		public ActionResult FactorForoosh()
		{
			return View();
		}
		[HttpPost]
		public ActionResult FactorForoosh(FactorForoosh factorForoosh)
		{
			_db.FactorForoosh.Add(factorForoosh);
			_db.SaveChanges();
			return RedirectToAction("FactorForoosh");
		}
		
		public ActionResult EditFactorForoosh(int id)
		{
			var index = _db.FactorForoosh.Find(id);
			return View(index);
		}
		[HttpPost]
		public ActionResult EditFactorForoosh(FactorForoosh factorForoosh)
		{
			_db.FactorForoosh.Update(factorForoosh);
			_db.SaveChanges();
			return RedirectToAction("FactorForoosh");
		}
        public ActionResult DeleteFactorForoosh(int id)
        {
            var rem = _db.FactorForoosh.Find(id);
            _db.FactorForoosh.Remove(rem);
            _db.SaveChanges();
            return RedirectToAction("FactorForooshList");
        }
        public ActionResult FactorForooshList()
        {
			var list=_db.FactorForoosh.ToList();
            return View(list);
        }
    }
}