using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoesShop1.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Moi nhap ten dang nhap")]
        public string adminName { set; get; }

        [Required(ErrorMessage = "Moi nhap mat khau")]
        public string password { set; get; }

        public bool RememberMe { get; set; }
    }
}