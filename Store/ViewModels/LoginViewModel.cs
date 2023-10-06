using System.ComponentModel.DataAnnotations;

namespace Store.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید"),Display(Name = "ایمیل")]
		public string Email { get; set; }

		[Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید"),Display(Name = "رمز عبور")]
		public string Password { get; set; }

		[Display(Name = "مرا به خاطر بسپار")]
		public bool RememberMe { get; set; }
	}
}
