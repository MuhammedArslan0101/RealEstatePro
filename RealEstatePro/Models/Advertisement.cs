using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstatePro.Models
{
    public class Advertisement
    {
        [Key]
        public int AdvId { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public string NumOfRoom { get; set; }
        public string NumOfBath { get; set; }
        public bool Credit { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public string Feature { get; set; }
        public string Telephone { get; set; }
        public string Addres { get; set; }

        public string UserName { get; set; }

        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int StatusId { get; set; }


        public int NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }


        public List<AdvPhoto> AdvPhotos { get; set; }







    }
}