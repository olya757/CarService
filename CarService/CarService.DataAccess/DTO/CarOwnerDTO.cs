using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.DTO
{
    public class CarOwnerDTO
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        public CarOwnerDTO(CarOwner carOwner)
        {
            ID = carOwner.ID;
            Surname = carOwner.Surname;
            Name = carOwner.Name;
            SecondName = carOwner.SecondName;
            Birthday = carOwner.Birthday;
            Phone = carOwner.Phone;
        }

        public CarOwnerDTO()
        {
            ID = 0;
            Surname = "";
            Name = "";
            SecondName = "";
            Birthday = DateTime.Now;
            Phone = "";
        }

        public CarOwner UpdateCarOwner(CarOwner carOwner)
        {
            carOwner.Birthday = Birthday;
            carOwner.Name = Name;
            carOwner.Phone = Phone;
            carOwner.SecondName = SecondName;
            carOwner.Surname = Surname;
            return carOwner;
        }
    }
}
