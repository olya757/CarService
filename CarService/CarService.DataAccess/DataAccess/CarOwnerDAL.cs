using CarService.DataAccess.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarService.DataAccess.DataAccess
{
    public class CarOwnerDAL:IDataRepository<CarOwner>
    {
        public void Add(CarOwner carOwner)
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

        public void Update(CarOwner carOwner, int id)
        {
            carOwner.ID = id;
            Add(carOwner);
        }

        public void Delete(int id)
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

        public List<CarOwner> GetIndex()
        {
            using (var db = new SampleContext())
            {

                return db.CarOwners.ToList();
            }
        }

        public CarOwner GetByID(int id)
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
