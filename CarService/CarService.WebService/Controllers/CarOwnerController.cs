using CarService.DataAccess.DTO;
using CarService.WebService.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/CarOwner/{Source}")]
    public class CarOwnerController : ApiController
    {
        private IDataRepository DataRepository;

        public CarOwnerController()
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
        public IEnumerable<CarOwnerDTO> Get()
        {
            var list = DataRepository.GetCarOwners();
            return list;
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public CarOwnerDTO Get(int id)
        {
            return DataRepository.GetCarOwnerByID(id);
        }

        // POST api/values
        [Route("")]
        [HttpPost]
        public void Post([FromBody] CarOwnerDTO value)
        {
            DataRepository.AddCarOwner(value);
        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]CarOwnerDTO value, int Source)
        {
            DataRepository.UpdateCarOwner(value, id);
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            DataRepository.DeleteCarOwner(id);
        }
    }
}
