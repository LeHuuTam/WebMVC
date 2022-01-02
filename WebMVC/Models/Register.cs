using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Bạn chưa nhập trường này")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(100)]
        public string Province { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(100)]
        public string District { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(200)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [StringLength(200)]
        public string ConfirmPassword { get; set; }
    }
}