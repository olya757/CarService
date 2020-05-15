﻿using CarService_Client.Model;
using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.ViewModel
{
    public class CarOwnerViewModel:ViewModel
    {
        private CarOwner carOwner;
                

        public CarOwnerViewModel(CarOwner carOwner, IAutoServiceModel autoServideModel):base(autoServideModel)
        {
            this.carOwner = carOwner;
        }

        public CarOwnerViewModel(IAutoServiceModel autoServiceModel):base(autoServiceModel)
        {
            carOwner = new CarOwner();
            carOwner.Birthday = DateTime.Now;

        }

        public int ID { get
            {
                return carOwner.ID;
            } 
        }

        public void Save()
        {
            int id = carOwner.ID;
            AutoServiceModel.AddCarOwner(carOwner);
            if (id == 0)
            {
                var cos = AutoServiceModel.GetCarOwners();
                var max = cos.Max(p => p.ID);
                carOwner = cos.First(p => p.ID == max);
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Surname
        {
            get
            {
                return carOwner.Surname;
            }
            set
            {
                carOwner.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Name
        {
            get
            {
                return carOwner.Name;
            }
            set
            {
                carOwner.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string SecondName
        {
            get
            {
                return carOwner.SecondName;
            }
            set
            {
                carOwner.SecondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        public DateTime Birthday
        {
            get
            {
                return carOwner.Birthday;
            }
            set
            {
                if (value.Year > 1900)
                {
                    carOwner.Birthday = value;
                    OnPropertyChanged(nameof(Birthday));
                }
            }
        }

        public string Phone
        {
            get
            {
                return carOwner.Phone;
            }
            set
            {

                carOwner.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

    }
}