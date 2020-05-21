﻿using CarService.DataAccess.DataAccess;
using CarService.DataAccess.DTO;
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
            Bind<IDataRepository>().To<DataRepository>();
            switch (Source)
            {
                case 1:
                    {
                        Bind<ICarOwnerDAL>().To<CarOwnerDAL>();
                        Bind<IOrderDAL>().To<OrderDAL>();
                        break;
                    }
                case 2:
                    {
                        Bind<IFileDataAccess>().To<XMLFileDataAccess>();
                        Bind<ICarOwnerDAL>().To<CarOwnerDAL_file>();
                        Bind<IOrderDAL>().To<OrderDAL_file>();
                        break;
                    }
                case 3:
                    {
                        Bind<IFileDataAccess>().To<BinaryFileDataAccess>();
                        Bind<ICarOwnerDAL>().To<CarOwnerDAL_file>();
                        Bind<IOrderDAL>().To<OrderDAL_file>();
                        break;
                    }
            }
        }
    }
}