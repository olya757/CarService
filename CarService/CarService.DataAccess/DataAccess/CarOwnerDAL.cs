using CarService.DataAccess.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarService.DataAccess.DataAccess
{
    public class CarOwnerDAL:ICarOwnerDAL
    {
        public void AddCarOwner(CarOwner carOwner)
        {
            using(var db = new SampleContext())
            {
                if (db.CarOwners.Any(p => p.ID == carOwner.ID))
                {
                    db.Entry(carOwner).State = EntityState.Modified;
                }
                else
                    db.CarOwners.Add(carOwner);
                db.SaveChanges();
            }
        }

        public void UpdateCarOwner(CarOwner carOwner, int id)
        {
            carOwner.ID = id;
            AddCarOwner(carOwner);
        }

        public void DeleteCarOwner(int id)
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

        public List<CarOwner> GetCarOwners()
        {
            using (var db = new SampleContext())
            {

                return db.CarOwners.ToList();
            }
        }

        public CarOwner GetCarOwnerByID(int id)
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
