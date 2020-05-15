using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarService_Client.Model
{
    [Serializable]
    public class AutoServiceModel:IAutoServiceModel
    {
        public int iCarOwners { get; set; }
        public int iOrders { get; set; }
        public string Path { get; set; }

        [XmlIgnore]
        public IFileDataAccess fileDataAccess;

        public AutoServiceModel()
        {
            CarOwners = new List<CarOwner>();
            Orders = new List<Order>();
        }

        public AutoServiceModel(IFileDataAccess fileDataAccess)
        {
            iCarOwners = 0;
            iOrders = 0;
            Path = fileDataAccess.Path;
            CarOwners = new List<CarOwner>();
            Orders = new List<Order>();
            this.fileDataAccess = fileDataAccess;
        }

        public List<CarOwner> CarOwners { get; set; }
        public List<Order> Orders { get; set; }

        public void AddCarOwner(CarOwner carOwner)
        {
            if (CarOwners.Any(p => p.ID == carOwner.ID))
            {
                var co = CarOwners.First(p => p.ID == carOwner.ID);
                co.Name = carOwner.Name;
                co.Surname = carOwner.Surname;
                co.SecondName = carOwner.SecondName;
                co.Phone = carOwner.Phone;
                co.Birthday = carOwner.Birthday;
            }
            else
            {
                iCarOwners++;
                carOwner.ID = iCarOwners;
                CarOwners.Add(carOwner);
            }
            fileDataAccess.SetModel(this);
        }

        public void UpdateCarOwner(CarOwner carOwner, int id)
        {
            carOwner.ID = id;
            AddCarOwner(carOwner);
        }

        public void DeleteCarOwner(int id)
        {
            if (CarOwners.Any(p => p.ID == id))
                CarOwners.Remove(CarOwners.First(p => p.ID == id));
            fileDataAccess.SetModel(this);
        }

        public List<CarOwner> GetCarOwners()
        {
            return CarOwners.ToList();
        }

        public CarOwner GetCarOwnerByID(int id)
        {
            if (CarOwners.Any(p => p.ID == id))
                return CarOwners.First(p => p.ID == id);
            return null;
        }

        public void AddOrder(Order order)
        {
            if (Orders.Any(o => o.ID == order.ID))
            {
                var ord = Orders.First(p => p.ID == order.ID);
                ord.NameOfWorks = order.NameOfWorks;
                ord.CarBrand = order.CarBrand;
                ord.CarModel = order.CarModel;
                ord.CarOwner = order.CarOwner;
                ord.OwnerID = order.OwnerID;
                ord.DateOfFinish = order.DateOfFinish;
                ord.DateOfStart = order.DateOfStart;
                ord.EnginePower = order.EnginePower;
                ord.Price = order.Price;
                ord.TypeOfTransmission = order.TypeOfTransmission;
                ord.YearOfManufacture = order.YearOfManufacture;
            }
            else
            {
                iOrders++;
                order.ID = iOrders;
                Orders.Add(order);
            }
            fileDataAccess.SetModel(this);
        }

        public void UpdateOrder(Order order, int id)
        {
            order.ID = id;
            AddOrder(order);
        }

        public void DeleteOrder(int id)
        {
            if (Orders.Any(p => p.ID == id))
                Orders.Remove(Orders.First(p => p.ID == id));
            fileDataAccess.SetModel(this);
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }

        public Order GetOrderByID(int id)
        {
            if (Orders.Any(p => p.ID == id))
                return Orders.First(p => p.ID == id);
            return null;
        }

    }
}
