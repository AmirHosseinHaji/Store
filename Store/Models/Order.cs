using Store.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
	public class Order
	{
		public Order()
		{
			User=new User();
			UserId = User.UserId;
			User.Email=User.Email;
			orderDetail=new List<OrderDetail>();
		}
		[Key]
		public int OrderId { get; set; }
		[Required]
		public int? UserId { get; set; } 
		public bool IsFinally { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
		public List<OrderDetail> orderDetail { get; set; }
	}
}
