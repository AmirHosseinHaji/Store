using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;

namespace Store.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام شخص")]
        public string UserName { get; set; }

        [MaxLength(300)]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده صحیح نیست")]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور خود را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار کلمه عبور با هم برابر نیستند")]
        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }
        [Display(Name="مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}