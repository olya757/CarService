using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DataAccess
{
    public interface ICarOwnerDAL
    {
        void AddCarOwner(CarOwner carOwner);

        void UpdateCarOwner(CarOwner order, int id);

        void DeleteCarOwner(int id);

        List<CarOwner> GetCarOwners();

        CarOwner GetCarOwnerByID(int id);
    }
}
