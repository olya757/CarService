using AutoMapper;
using CarService.DataAccess.DataAccess;
using CarService.DataAccess.DTO;
using CarService.DataAccess.Model;
using CarService.WebService.App_Start;
using CarService.WebService.Mapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CarService.WebService.Controllers
{
    
    [RoutePrefix("api/Order/{Source}")]
    public class OrderController : ApiController
    {
        private IDataRepository<Order> DataRepository;
        private IMapper mapper;
        public OrderController()
        {
            mapper = AutoMapperProfile.InitializeAutoMapper().CreateMapper();
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
                DataRepository = kernel.Get<IDataRepository<Order>>();
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
            return mapper.Map<IEnumerable<OrderDTO>>( DataRepository.GetIndex());
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public OrderDTO Get(int id)
        {
            return mapper.Map<OrderDTO>(DataRepository.GetByID(id));
        }

        // POST api/values
        [Route("")]
        [HttpPost]
        public void Post([FromBody]OrderDTO value)
        {
            DataRepository.Add(mapper.Map<Order>( value));
        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]OrderDTO value)
        {
            DataRepository.Update(mapper.Map<Order>(value), id);
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            DataRepository.Delete(id);
        }
    }
}
