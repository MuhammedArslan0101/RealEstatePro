using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    // Arsa dükkan daire vilaa
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

    }
}