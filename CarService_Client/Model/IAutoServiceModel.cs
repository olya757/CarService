using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.Model
{
    public interface IAutoServiceModel
    {
        void AddCarOwner(CarOwner carOwner);

        void UpdateCarOwner(CarOwner carOwner, int id);

        void DeleteCarOwner(int id);

        List<CarOwner> GetCarOwners();

        CarOwner GetCarOwnerByID(int id);

        void AddOrder(Order order);

        void UpdateOrder(Order order, int id);

        void DeleteOrder(int id);

        List<Order> GetOrders();

        Order GetOrderByID(int id);
    }
}
