using CarService.DataAccess.Model;
using CarService.DataAccess.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DataAccess
{
    public class CarOwnerDAL_file :ICarOwnerDAL
    {
        private AutoServiceModel autoServiceModel;
               
        public CarOwnerDAL_file(IFileDataAccess fileDataAccess)
        {
            autoServiceModel = new AutoServiceModel(fileDataAccess);
        }
        public void AddCarOwner(CarOwner CarOwner)
        {
            autoServiceModel.AddCarOwner(CarOwner);
        }

        public void DeleteCarOwner(int id)
        {
            autoServiceModel.DeleteCarOwner(id);
        }

        public CarOwner GetCarOwnerByID(int id)
        {
            return autoServiceModel.GetCarOwnerByID(id);
        }

        public List<CarOwner> GetCarOwners()
        {
            return autoServiceModel.GetCarOwners();
        }

        public void UpdateCarOwner(CarOwner CarOwner, int id)
        {
            autoServiceModel.UpdateCarOwner(CarOwner, id);
        }
    }
}
