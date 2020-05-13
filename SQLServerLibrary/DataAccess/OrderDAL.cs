﻿using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerLibrary.DataAccess
{
    public static class OrderDAL
    {
        public static void AddOrder(Order order)
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

        public static void UpdateOrder(Order order, int id)
        {
            order.ID = id;
            AddOrder(order);
        }

        public static void DeleteOrder(int id)
        {
            using (var db = new SampleContext())
            {
                if (db.Orders.Any(p => p.ID == id))
                {
                    db.Orders.Remove(db.Orders.First(p => p.ID == id));
                    db.SaveChanges();
                }
            }
        }

        public static List<Order> GetOrders()
        {
            using (var db = new SampleContext())
            {
                return db.Orders.ToList();
            }
        }

        public static Order GetOrderByID(int id)
        {
            using (var db = new SampleContext())
            {
                if (db.Orders.Any(p => p.ID == id))
                    return db.Orders.First(p => p.ID == id);
                return null;
            }
        }

        public static CarOwner GetCarOwner(Order order)
        {
            return CarOwnerDAL.GetCarOwnerByID(order.CarOwnerID);
        }
    }
}