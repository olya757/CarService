using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SQLServerLibrary.Model
{
    [DataContract]
    [Serializable]
    public class CarOwner
    {
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
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

    [DataContract]
    [Serializable]
    public class Order
    {
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string CarBrand { get; set; }
        [DataMember]
        public string CarModel { get; set; }
        [DataMember]
        public int YearOfManufacture { get; set; }
        [DataMember]
        public TypeOfTransmission TypeOfTransmission { get; set; }
        [DataMember]
        public double EnginePower { get; set; }
        [DataMember]
        public string NameOfWorks { get; set; }
        [DataMember]
        public DateTime DateOfStart { get; set; }
        [DataMember]
        public DateTime DateOfFinish { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int OwnerID { get; set; }

        [IgnoreDataMember]
        [ForeignKey("OwnerID")]
        public CarOwner CarOwner { get; set; }
        

    }
}
