using CarService.DataAccess.Model;
using CarService.DataAccess.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DataAccess
{
    public class CarOwnerDAL_file :IDataRepository<CarOwner>
    {
        private AutoServiceModel autoServiceModel;
               
        public CarOwnerDAL_file(IFileDataAccess fileDataAccess)
        {
            autoServiceModel = fileDataAccess.GetModel();
        }
        public void Add(CarOwner CarOwner)
        {
            autoServiceModel.AddCarOwner(CarOwner);
        }

        public void Delete(int id)
        {
            autoServiceModel.DeleteCarOwner(id);
        }

        public CarOwner GetByID(int id)
        {
            return autoServiceModel.GetCarOwnerByID(id);
        }

        public List<CarOwner> GetIndex()
        {
            return autoServiceModel.GetCarOwners();
        }

        public void Update(CarOwner CarOwner, int id)
        {
            autoServiceModel.UpdateCarOwner(CarOwner, id);
        }
    }
}
