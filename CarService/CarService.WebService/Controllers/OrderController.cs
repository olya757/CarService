﻿using CarService.DataAccess.DTO;
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
        private IDataRepository DataRepository;

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
                DataRepository = kernel.Get<IDataRepository>();
            }
            catch(Exception e)
            {
                var a = 3;
            }
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            
            return DataRepository.GetOrders();
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public OrderDTO Get(int id)
        {
            return DataRepository.GetOrderByID(id);
        }

        // POST api/values
        [Route("")]
        [HttpPost]
        public void Post([FromBody]OrderDTO value)
        {
            DataRepository.AddOrder(value);
        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]OrderDTO value)
        {
            DataRepository.UpdateOrder(value, id);
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            DataRepository.DeleteOrder(id);
        }
    }
}