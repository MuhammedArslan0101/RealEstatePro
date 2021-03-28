using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    public class AdvPhoto
    {
  [Key]
        public int AdvPhotoId { get; set; }
        public string AdvPhotoName { get; set; }

        public int AdvId { get; set; }
        public virtual Advertisement Advertisement { get; set; }

    }
    
}