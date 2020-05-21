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
    [RoutePrefix("api/CarOwner/{Source}")]
    public class CarOwnerController : ApiController
    {
        private ICarOwnerDAL CarOwnerDAL;

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
                CarOwnerDAL = kernel.Get<ICarOwnerDAL>();
            }
            catch(Exception e)
            {

            }
        }

        [Route("")]
        [HttpGet]        
        public IEnumerable<CarOwner> Get()
        {
            var list = CarOwnerDAL.GetCarOwners();
            return list;
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public CarOwner Get(int id, int Source)
        {
            return CarOwnerDAL.GetCarOwnerByID(id);
        }

        // POST api/values
        [Route("")]
        [HttpPost]
        public void Post([FromBody] CarOwner value, int Source)
        {
            CarOwnerDAL.AddCarOwner(value);
        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]CarOwner value, int Source)
        {
            CarOwnerDAL.UpdateCarOwner(value, id);
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            CarOwnerDAL.DeleteCarOwner(id);
        }
    }
}
