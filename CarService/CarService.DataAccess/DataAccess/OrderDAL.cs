using CarService.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarService.DataAccess.DataAccess
{
    public class OrderDAL : IDataRepository<Order>
    {
        public void Add(Order order)
        {
            using(var db = new SampleContext())
            {
                if (db.Orders.Any(o => o.ID == order.ID))
                    db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                else
                    db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order, int id)
        {
            order.ID = id;
            Add(order);
        }

        public void Delete(int id)
        {
            using (var db = new SampleContext())
            {
                if (db.Orders.Any(p => p.ID == id))
                {
                    var order = db.Orders.First(o => o.ID == id);
                    int cnt = db.Orders.Count();
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    int cnt2 = db.Orders.Count();
                }
            }
        }

        public List<Order> GetIndex()
        {
            using (var db = new SampleContext())
            {
                return db.Orders.ToList();
            }
        }

        public Order GetByID(int id)
        {
            using (var db = new SampleContext())
            {
                if (db.Orders.Any(p => p.ID == id))
                    return db.Orders.First(p => p.ID == id);
                return null;
            }
        }
    }
}
