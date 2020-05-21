using CarService.DataAccess.DataAccess;
using CarService.DataAccess.Model;
using CarService.WebService.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebAPI.Controllers
{
    
    [RoutePrefix("api/Order/{Source}")]
    public class OrderController : ApiController
    {
        private IOrderDAL OrderDAL;

        public OrderController()
        {
        }


        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            try
            {
                var str = controllerContext.Request.RequestUri.Segments[3];
                if (str.IndexOf('/') >= 0)
                {
                    str = str.Remove(str.IndexOf('/'));
                }
                int source = int.Parse(str);
                var kernel = new StandardKernel(new SourceNinjectModule(source));
                OrderDAL = kernel.Get<IOrderDAL>();
            }
            catch(Exception e)
            {

            }
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            
            return OrderDAL.GetOrders();
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public Order Get(int id)
        {
            return OrderDAL.GetOrderByID(id);
        }

        // POST api/values
        [Route("")]
        [HttpPost]
        public void Post([FromBody]Order value, int Source)
        {
            OrderDAL.AddOrder(value);
        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]Order value, int Source)
        {
            OrderDAL.UpdateOrder(value, id);
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id, int Source)
        {
            OrderDAL.DeleteOrder(id);
        }
    }
}
