using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
	public class OrderDetail
	{
		public OrderDetail()
		{
			kala=new Kala();
			KalaId=kala.KalaId;
			order=new Order();
		}
		[Key]
		public int DetailId { get; set; }
		[Required]
		public int OrderId { get; set; }
		[Required]
		public int KalaId { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price { get; set; }
		[Required]
		public int Count { get; set; }

		[ForeignKey("OrderId")]
		public Order order { get; set; }

		[ForeignKey("KalaId")]
		public Kala kala { get; set; }

		public decimal getTotalPrice()
		{
			var price = kala.Price;
			var discount = kala.Discount;
			return price - discount;
		}
	}
}
