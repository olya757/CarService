using CarService.DataAccess.DataAccess;
using CarService.DataAccess.Model;
using CarService.DataAccess.Source;
using Ninject.Modules;

namespace CarService.WebService.App_Start
{
    public class SourceNinjectModule : NinjectModule
    {
        public  int Source { get; set; }
        public SourceNinjectModule(int source)
        {
            Source = source;
        }

        public override void Load()
        {
            switch (Source)
            {
                case 1:
                    {
                        Bind<IDataRepository<CarOwner>>().To<CarOwnerDAL>();
                        Bind<IDataRepository<Order>>().To<OrderDAL>();
                        break;
                    }
                case 2:
                    {
                        Bind<IFileDataAccess>().To<XMLFileDataAccess>();
                        Bind<IDataRepository<CarOwner>>().To<CarOwnerDAL_file>();
                        Bind<IDataRepository<Order>>().To<OrderDAL_file>();
                        break;
                    }
                case 3:
                    {
                        Bind<IFileDataAccess>().To<BinaryFileDataAccess>();
                        Bind<IDataRepository<CarOwner>>().To<CarOwnerDAL_file>();
                        Bind<IDataRepository<Order>>().To<OrderDAL_file>();
                        break;
                    }
            }
        }
    }
}