using CarService.DataAccess.DataAccess;
using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO.Repository
{
    //public class DataRepository : IDataRepository
    //{
    //    private IOrderDAL OrderDAL;
    //    private ICarOwnerDAL CarOwnerDAL;

    //    public DataRepository(IOrderDAL orderDAL, ICarOwnerDAL carOwnerDAL)
    //    {
    //        OrderDAL = orderDAL;
    //        CarOwnerDAL = carOwnerDAL;
    //    }

    //    public void AddCarOwner(CarOwnerDTO carOwner)
    //    {
    //        var _carOwner = CarOwnerDAL.GetCarOwnerByID(carOwner.ID);
    //        if(_carOwner is null)
    //        {
    //            _carOwner = new CarOwner();
    //        }
    //        CarOwnerDAL.AddCarOwner(carOwner.UpdateCarOwner(_carOwner));
    //    }

    //    public void AddOrder(OrderDTO order)
    //    {
    //        var _order = OrderDAL.GetOrderByID(order.ID);
    //        if (_order is null)
    //        {
    //            _order = new Order();
    //        }
    //        OrderDAL.AddOrder(order.UpdateOrder(_order));
    //    }

    //    public void DeleteCarOwner(int id)
    //    {
    //        CarOwnerDAL.DeleteCarOwner(id);
    //    }

    //    public void DeleteOrder(int id)
    //    {
    //        OrderDAL.DeleteOrder(id);
    //    }

    //    public CarOwnerDTO GetCarOwnerByID(int id)
    //    {
    //        var _carowner = CarOwnerDAL.GetCarOwnerByID(id);
    //        return new CarOwnerDTO(_carowner);
    //    }

    //    public List<CarOwnerDTO> GetCarOwners()
    //    {
    //        List<CarOwnerDTO> carOwnerDTOs = new List<CarOwnerDTO>();
    //        foreach(var co in CarOwnerDAL.GetCarOwners())
    //        {
    //            carOwnerDTOs.Add(new CarOwnerDTO(co));
    //        }
    //        return carOwnerDTOs;
    //    }

    //    public OrderDTO GetOrderByID(int id)
    //    {
    //        var _order = OrderDAL.GetOrderByID(id);
    //        return new OrderDTO(_order);
    //    }

    //    public List<OrderDTO> GetOrders()
    //    {
    //        List<OrderDTO> orderDTOs = new List<OrderDTO>();
    //        foreach (var o in OrderDAL.GetOrders())
    //        {
    //            orderDTOs.Add(new OrderDTO(o));
    //        }
    //        return orderDTOs;
    //    }

    //    public void UpdateCarOwner(CarOwnerDTO carOwner, int id)
    //    {
    //        var _carOwner = CarOwnerDAL.GetCarOwnerByID(id);
    //        CarOwnerDAL.UpdateCarOwner(carOwner.UpdateCarOwner(_carOwner), id);
    //    }

    //    public void UpdateOrder(OrderDTO order, int id)
    //    {
    //        var _order = OrderDAL.GetOrderByID(id);
    //        OrderDAL.UpdateOrder(order.UpdateOrder(_order), id);
    //    }
    //}
}
