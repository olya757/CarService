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
    public class OrderXMLController : ApiController
    {
        private AutoServiceModel autoServiceModel;
        public OrderXMLController()
        {
            autoServiceModel = XMLFileDataAccess.GetModel();
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
            XMLFileDataAccess.SetModel(autoServiceModel);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Order value)
        {
            autoServiceModel.UpdateOrder(value, id);
            XMLFileDataAccess.SetModel(autoServiceModel);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            autoServiceModel.DeleteOrder(id);
            XMLFileDataAccess.SetModel(autoServiceModel);
        }
    }
}
