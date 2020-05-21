using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int YearOfManufacture { get; set; }
        public TypeOfTransmission TypeOfTransmission { get; set; }
        public double EnginePower { get; set; }
        public string NameOfWorks { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        public int Price { get; set; }
        public int OwnerID { get; set; }

        public OrderDTO(Order order)
        {
            ID = order.ID;
            CarBrand = order.CarBrand;
            CarModel = order.CarModel;
            YearOfManufacture = order.YearOfManufacture;
            TypeOfTransmission = order.TypeOfTransmission;
            EnginePower = order.EnginePower;
            NameOfWorks = order.NameOfWorks;
            DateOfStart = order.DateOfStart;
            DateOfFinish = order.DateOfFinish;
            Price = order.Price;
            OwnerID = order.OwnerID;
        }

        public OrderDTO()
        {
            ID = 0;
            CarBrand = "";
            CarModel = "";
            YearOfManufacture = 1900;
            TypeOfTransmission = TypeOfTransmission.front;
            EnginePower = 0;
            NameOfWorks = "";
            DateOfStart = DateTime.Now;
            DateOfFinish = DateTime.Now;
            Price = 0;
            OwnerID = 0;
        }

        public Order UpdateOrder(Order order)
        {
            order.CarBrand = CarBrand;
            order.CarModel = CarModel;
            order.DateOfFinish = DateOfFinish;
            order.DateOfStart = DateOfStart;
            order.EnginePower = EnginePower;
            order.NameOfWorks = NameOfWorks;
            order.OwnerID = OwnerID;
            order.Price = Price;
            order.TypeOfTransmission = TypeOfTransmission;
            order.YearOfManufacture = YearOfManufacture;

            return order;
        }
    }
}
