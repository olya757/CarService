using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int YearOfManufacture { get; set; }
        public TypeOfTransmission TypeOfTransmission { get; set; }
        public double EnginePower { get; set; }
        public string NameOfWorks { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        public int Price { get; set; }
        public int OwnerID { get; set; }

       
    }
}
