using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}