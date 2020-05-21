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

    }
}
