using AutoMapper;
using CarService.DataAccess.DTO;
using CarService.DataAccess.Model;

namespace CarService.WebService.Mapper
{ 
    public class AutoMapperProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarOwner, CarOwnerDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ReverseMap();

                cfg.CreateMap<Order, OrderDTO>()
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                    .ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.CarBrand))
                    .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.CarModel))
                    .ForMember(dest => dest.DateOfFinish, opt => opt.MapFrom(src => src.DateOfFinish))
                    .ForMember(dest => dest.DateOfStart, opt => opt.MapFrom(src => src.DateOfStart))
                    .ForMember(dest => dest.EnginePower, opt => opt.MapFrom(src => src.EnginePower))
                    .ForMember(dest => dest.NameOfWorks, opt => opt.MapFrom(src => src.NameOfWorks))
                    .ForMember(dest => dest.OwnerID, opt => opt.MapFrom(src => src.OwnerID))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.TypeOfTransmission, opt => opt.MapFrom(src => src.TypeOfTransmission))
                    .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.YearOfManufacture))
                    .ReverseMap();
            });

            return config;
        }

       
    }
}