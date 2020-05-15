using SQLServerLibrary.DataAccess;
using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CarOwnerController : ApiController
    {
        public IEnumerable<CarOwner> Get()
        {
            var list = CarOwnerDAL.GetCarOwners();
            return list;
        }

        // GET api/values/5
        public CarOwner Get(int id)
        {
            return CarOwnerDAL.GetCarOwnerByID(id);
        }

        // POST api/values
        public void Post([FromBody] CarOwner value)
        {
            CarOwnerDAL.AddCarOwner(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]CarOwner value)
        {
            CarOwnerDAL.UpdateCarOwner(value, id);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            CarOwnerDAL.DeleteCarOwner(id);
        }
    }
}
