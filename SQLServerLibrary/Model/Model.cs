using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerLibrary.Model
{
    public class CarOwner
    {
        [Key]
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        [InverseProperty("CarOwner")]
        public virtual ICollection<Order> Orders { get; set; }
    }

    public enum TypeOfTransmission
    {
        front,
        rear,
        full
    }

    public class Order
    {
        [Key]
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

        [ForeignKey("OwnerID")]
        public virtual CarOwner CarOwner { get; set; }
        public int OwnerID { get; set; }

    }
}
