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
    [RoutePrefix("api/CarOwner/{Source}")]
    public class CarOwnerController : ApiController
    {
        private IDataRepository<CarOwner> DataRepository;
        private IMapper mapper;
        public CarOwnerController()
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
                DataRepository = kernel.Get<IDataRepository<CarOwner>>();
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
            var list = DataRepository.GetIndex();
            return mapper.Map<List<CarOwnerDTO>>(list);
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public CarOwnerDTO Get(int id)
        {
            return mapper.Map<CarOwnerDTO>(DataRepository.GetByID(id));
        }

        // POST api/values
        [Route("")]
        [HttpPost]
        public void Post([FromBody] CarOwnerDTO value)
        {
            DataRepository.Add(mapper.Map<CarOwner>(value));
        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]CarOwnerDTO value, int Source)
        {
            DataRepository.Update( mapper.Map<CarOwner>(value), id);
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
