using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RealEstatePro.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        //veritabanın tablolarını belirmek için 
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvPhoto> AdvPhotos { get; set; }

        public DbSet<FooterLink> foterLinks { get; set; }



    }
}