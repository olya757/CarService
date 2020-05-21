using CarService.DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DTO
{
    public interface IDataRepository 
    {
        void AddCarOwner(CarOwnerDTO carOwner);

        void UpdateCarOwner(CarOwnerDTO order, int id);

        void DeleteCarOwner(int id);

        List<CarOwnerDTO> GetCarOwners();

        CarOwnerDTO GetCarOwnerByID(int id);

        void AddOrder(OrderDTO order);

        void UpdateOrder(OrderDTO order, int id);

        void DeleteOrder(int id);

        List<OrderDTO> GetOrders();

        OrderDTO GetOrderByID(int id);
    }
}
