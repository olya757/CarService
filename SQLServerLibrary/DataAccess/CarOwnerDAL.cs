using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerLibrary.DataAccess
{
    public static class CarOwnerDAL
    {
        public static void AddCarOwner(CarOwner carOwner)
        {
            using(var db = new SampleContext())
            {
                db.CarOwners.Add(carOwner);
                db.SaveChanges();
            }
        }

        public static List<CarOwner> GetCarOwners()
        {
            using (var db = new SampleContext())
            {
                return db.CarOwners.ToList();
            }
        }
    }
}
