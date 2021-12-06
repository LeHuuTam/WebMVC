using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Bạn chưa điền tên đăng nhập!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn chưa điền mật khẩu!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}