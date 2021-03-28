using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{

    //ilan durumu satilik yada kiralik
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public List<Type> Types { get; set; }

    }
}