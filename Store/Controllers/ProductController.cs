using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Security.Claims;
using Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
	public class ProductController : Controller
	{
		private MyDBShopContext _db;
		public ProductController(MyDBShopContext db)
		{
			_db = db;
		}

		public IActionResult ShowCartUser()
		{
			var list = _db.OrderDetail.ToList();
			return View(list);
		}

		[Authorize]
		public IActionResult AddCartUser(int itemId)
		{
			int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
			var product = _db.Kala.SingleOrDefault(c => c.ItemId == itemId);
			Order order = _db.Order.SingleOrDefault(c => c.UserId == userId && !c.IsFinally);
			if (order == null)
			{
				
				order = new Order()
				{
					IsFinally = false,
					UserId = userId
				};
				_db.Order.Add(order);
				_db.OrderDetail.Add(new OrderDetail()
				{
					Price = product.Price,
					Count = 1,
					KalaId = itemId,
					OrderId = order.OrderId,
				});
				_db.SaveChanges();
			}
			else
			{
				var detail = _db.OrderDetail.SingleOrDefault(c => c.OrderId == order.OrderId && c.KalaId == itemId);
				if (detail == null)
				{
					_db.OrderDetail.Add(new OrderDetail()
					{
						Price = product.Price,
						Count = 1,
						KalaId = itemId,
						OrderId = order.OrderId
					});
				}
				else
				{
					detail.Count += 1;
					_db.Update(detail);
				}
				_db.SaveChanges();
			}
			return RedirectToAction("Index","Home");
		}
		
	}
}
