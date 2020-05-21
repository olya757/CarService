using CarService.DataAccess.Model;
using CarService.DataAccess.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace CarService.DataAccess.DataAccess
{
    public class OrderDAL : IOrderDAL
    {
        public void AddOrder(Order order)
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

        public void UpdateOrder(Order order, int id)
        {
            order.ID = id;
            AddOrder(order);
        }

        public void DeleteOrder(int id)
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

        public List<Order> GetOrders()
        {
            using (var db = new SampleContext())
            {
                return db.Orders.ToList();
            }
        }

        public Order GetOrderByID(int id)
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
