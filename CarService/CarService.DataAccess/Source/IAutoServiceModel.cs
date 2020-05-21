using CarService.DataAccess.Model;
using System.Collections.Generic;

namespace CarService.DataAccess.Source
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
