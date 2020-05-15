using SQLServerLibrary.DataAccess;
using SQLServerLibrary.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            return OrderDAL.GetOrders();
        }

        // GET api/values/5
        public Order Get(int id)
        {
            return OrderDAL.GetOrderByID(id);
        }

        // POST api/values
        public void Post([FromBody]Order value)
        {
            OrderDAL.AddOrder(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Order value)
        {
            OrderDAL.UpdateOrder(value, id);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            OrderDAL.DeleteOrder(id);
        }
    }
}
