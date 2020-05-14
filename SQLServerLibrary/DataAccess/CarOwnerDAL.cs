using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
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
                if (db.CarOwners.Any(p => p.ID == carOwner.ID))
                {
                    db.Entry(carOwner).State = System.Data.Entity.EntityState.Modified;
                }
                else
                    db.CarOwners.Add(carOwner);
                db.SaveChanges();
            }
        }

        public static void UpdateCarOwner(CarOwner carOwner, int id)
        {
            carOwner.ID = id;
            AddCarOwner(carOwner);
        }

        public static void DeleteCarOwner(int id)
        {
            using (var db = new SampleContext())
            {
                if (db.CarOwners.Any(p => p.ID == id))
                {
                    int cnt = db.CarOwners.Count();
                    var co = db.CarOwners.First(c => c.ID == id);
                    db.CarOwners.Remove(co);
                    db.SaveChanges();
                    int cnt2 = db.CarOwners.Count();
                }
            }
        }

        public static List<CarOwner> GetCarOwners()
        {
            using (var db = new SampleContext())
            {

                return db.CarOwners.ToList();
            }
        }

        public static CarOwner GetCarOwnerByID(int id)
        {            
            using (var db = new SampleContext())
            {
                if (db.CarOwners.Any(p => p.ID == id))
                {
                    return db.CarOwners.First(p => p.ID == id);
                }
                return null;
            }            
        }

        
    }
}
