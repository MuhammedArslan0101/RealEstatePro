using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    public class EditProfile
    {
       
        public string id { get; set; }
        [Required]
        [DisplayName("Adi")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadi")]
        public string  Surname { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Geçerli Email giriniz")]
        public string Email { get; set; }
        [Required]
        [DisplayName("KullanıcıAdi")]
        public string Username { get; set; }

    }
}