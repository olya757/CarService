using CarService.DataAccess.Model;
using CarService.DataAccess.Source;
using System.Collections.Generic;

namespace CarService.DataAccess.DataAccess
{
    public class OrderDAL_file : IDataRepository<Order>
    {
        private AutoServiceModel autoServiceModel;
        

        public OrderDAL_file(IFileDataAccess fileDataAccess)
        {
            autoServiceModel = fileDataAccess.GetModel();
        }
        public void Add(Order order)
        {
            autoServiceModel.AddOrder(order);
        }

        public void Delete(int id)
        {
            autoServiceModel.DeleteOrder(id);
        }

        public Order GetByID(int id)
        {
            return autoServiceModel.GetOrderByID(id);
        }

        public List<Order> GetIndex()
        {
            return autoServiceModel.GetOrders();
        }

        public void Update(Order order, int id)
        {
            autoServiceModel.UpdateOrder(order, id);
        }
    }
}
