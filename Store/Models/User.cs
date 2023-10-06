using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Store.Models
{
	public class User
	{
		public User()
		{
			order = new List<Order>();
		}
		[Key]
		public int UserId { get; set; }
		[Required(ErrorMessage="لطفا ایمیل خود را وارد کنید")]
		[EmailAddress(ErrorMessage="ایمیل وارد شده صحیح نیست")]
		[MaxLength(300,ErrorMessage="ایمیل وارد شده بیشتر از  حد مجاز 300 کاراکتر وارد شده است")]
		public string Email { get; set; }
		[Required(ErrorMessage="لطفا رمز عبور خود را وارد کنید")]
		public string Password { get; set; }

		public List<Order> order { get; set; }
	}
}
