using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        //Many District to one City 
        public int CityId { get; set; }
        public virtual City City { get; set; }


        public List<Neighborhood> Neighborhoods { get; set; }





    }
}