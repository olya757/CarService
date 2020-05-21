using CarService.DataAccess.Model;
using CarService.DataAccess.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DataAccess
{
    public class OrderDAL_file : IOrderDAL
    {
        private AutoServiceModel autoServiceModel;
        

        public OrderDAL_file(IFileDataAccess fileDataAccess)
        {
            autoServiceModel = new AutoServiceModel( fileDataAccess);
        }
        public void AddOrder(Order order)
        {
            autoServiceModel.AddOrder(order);
        }

        public void DeleteOrder(int id)
        {
            autoServiceModel.DeleteOrder(id);
        }

        public Order GetOrderByID(int id)
        {
            return autoServiceModel.GetOrderByID(id);
        }

        public List<Order> GetOrders()
        {
            return autoServiceModel.GetOrders();
        }

        public void UpdateOrder(Order order, int id)
        {
            autoServiceModel.UpdateOrder(order, id);
        }
    }
}
