using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        [XmlIgnore]
        [IgnoreDataMember]
        [JsonIgnore] 
        [ForeignKey("CarOwner")]
        public List<Order> Orders { get; set; }
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

        
        public int CarOwnerID { get; set; }
        [ForeignKey("CarOwnerID")]
        public CarOwner CarOwner { get; set; }
        

    }
}
