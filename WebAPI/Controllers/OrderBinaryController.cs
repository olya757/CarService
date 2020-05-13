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
    public class OrderBinaryController : ApiController
    {
        private AutoServiceModel autoServiceModel;
        public OrderBinaryController()
        {
            autoServiceModel = BinaryFileDataAccess.GetModel();
        }
        public IEnumerable<Order> Get()
        {
            return autoServiceModel.GetOrders();
        }

        // GET api/values/5
        public Order Get(int id)
        {
            return autoServiceModel.GetOrderByID(id);
        }

        // POST api/values
        public void Post([FromBody]Order value)
        {
            autoServiceModel.AddOrder(value);
            BinaryFileDataAccess.SetModel(autoServiceModel);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Order value)
        {
            autoServiceModel.UpdateOrder(value, id);
            BinaryFileDataAccess.SetModel(autoServiceModel);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            autoServiceModel.DeleteOrder(id);
            BinaryFileDataAccess.SetModel(autoServiceModel);
        }
    }
}
