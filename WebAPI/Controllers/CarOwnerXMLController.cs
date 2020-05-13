using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CarOwnerXMLController : ApiController
    {
        private AutoServiceModel autoServiceModel;
        public CarOwnerXMLController()
        {
            autoServiceModel = XMLFileDataAccess.GetModel();
        }
        public IEnumerable<CarOwner> Get()
        {
            return autoServiceModel.GetCarOwners();
        }

        // GET api/values/5
        public CarOwner Get(int id)
        {
            return autoServiceModel.GetCarOwnerByID(id);
        }

        // POST api/values
        public void Post([FromBody]CarOwner value)
        {
            autoServiceModel.AddCarOwner(value);
            XMLFileDataAccess.SetModel(autoServiceModel);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]CarOwner value)
        {
            autoServiceModel.UpdateCarOwner(value, id);
            XMLFileDataAccess.SetModel(autoServiceModel);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            autoServiceModel.DeleteCarOwner(id);
            XMLFileDataAccess.SetModel(autoServiceModel);
        }
    }
}
