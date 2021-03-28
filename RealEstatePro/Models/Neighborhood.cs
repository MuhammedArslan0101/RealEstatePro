using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    public class Neighborhood
    {
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }

        //Many District to one Neighborhood 
        public int DistrictId { get; set; }
        public virtual District District { get; set; }

    }
}