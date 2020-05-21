using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DataAccess
{
    public interface IOrderDAL
    {
        void AddOrder(Order order);

        void UpdateOrder(Order order, int id);

        void DeleteOrder(int id);

        List<Order> GetOrders();

        Order GetOrderByID(int id);
    }
}
