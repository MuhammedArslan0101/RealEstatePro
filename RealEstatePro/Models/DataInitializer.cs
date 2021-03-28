using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RealEstatePro.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var city = new List<City>()
            {
                new City() {CityName="Şam"},
                new City(){CityName="Ankara"},
                new City(){CityName="izmir"}


            };
            foreach (var item in city)
            {
                context.Cities.Add(item);
            }
            context.SaveChanges();
            /////////////////////////////////////////////////////////////

            var district = new List<District>()
            {
                new District() {DistrictName="Fatih" , CityId=1},
                new District() {DistrictName="Çanakaya" , CityId=2},
                new District() {DistrictName="Çekirge" , CityId=3}
            };
            foreach (var item in district)
            {
                context.Districts.Add(item);
            }
            context.SaveChanges();
            ////////////////////////////////////////////////////////////////////////
            var neighood = new List<Neighborhood>()
            {
                 new Neighborhood() { NeighborhoodName="YediKule" , DistrictId=1},
                new Neighborhood() {NeighborhoodName="ÇankayaSemt1" ,DistrictId=2} ,
                new Neighborhood() {NeighborhoodName="BursaÇekirgeSemt" ,DistrictId=3}

            };
            foreach (var item in neighood)
            {
                context.Neighborhoods.Add(item);
            }
            context.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////////////
            var status = new List<Status>() {
                new Status(){ StatusName="Satlik"},
                new Status() {StatusName="Kiralik"}
            };
            foreach (var item in status)
            {
                context.Statuses.Add(item);
            }
            context.SaveChanges();
            /////////////////////////////////////////////////
            //Tip
            var type = new List<Type>()
            {
                new Type() {TypeName="Ev" , StatusId=1},
                 new Type(){TypeName="dükkan" , StatusId=1},
                new Type(){TypeName="Ev" , StatusId=2},
                new Type(){TypeName="dükkan" , StatusId=2}
            };
            foreach (var item in type)
            {
                context.Types.Add(item);
            }
            context.SaveChanges();
            /////////////
            var adv = new List<Advertisement>() {
                new Advertisement() {
                    Description="ev" , Addres="Türkiye" , NumOfRoom="2" , NumOfBath="2" ,Credit=true , Price=2500 ,NeighborhoodId=1 ,DistrictId=1, CityId=1 , StatusId=1 , TypeId=1 ,Area=75 , Telephone="6342964" ,Floor=3, Feature="Kötü" ,UserName="Muhammed" },
                new Advertisement() {
                    Description="Villa" , Addres="Suriye" , NumOfRoom="3" , NumOfBath="3" ,Credit=false , Price=200 ,NeighborhoodId=2 ,DistrictId=2, CityId=2 , StatusId=2 , TypeId=4 ,Area=50 , Telephone="0531695558" ,Floor=5, Feature="iyi" ,UserName="orhan" },
                };
            foreach (var item in adv)
            {
                context.Advertisements.Add(item);
            }
            context.SaveChanges();

            var photo = new List<AdvPhoto>() {
                new AdvPhoto() { AdvPhotoName="muhammed.jpg" , AdvId=1},
                new AdvPhoto() { AdvPhotoName="3.jpg" , AdvId=1},
                new AdvPhoto() { AdvPhotoName="2.jpg" , AdvId=2},
                 new AdvPhoto() { AdvPhotoName="1.jpg" , AdvId=2}

            };
            foreach (var item in photo)
            {
                context.AdvPhotos.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}