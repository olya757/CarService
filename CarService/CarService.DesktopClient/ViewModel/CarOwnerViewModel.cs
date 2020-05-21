using CarService.DataAccess.Model;
using CarService.DesktopClient.Model;
using System;
using System.Linq;

namespace CarService.DesktopClient.ViewModel
{
    public class CarOwnerViewModel:ViewModel
    {
        private CarOwner carOwner;
                

        public CarOwnerViewModel(CarOwner carOwner)
        {
            this.carOwner = carOwner;
            this.PropertyChanged += CarOwnerViewModel_PropertyChanged;
        }

        bool changed = false;
        private void CarOwnerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            changed = true;
        }

        public CarOwnerViewModel()
        {
            carOwner = new CarOwner();
            carOwner.Birthday = DateTime.Now;
            this.PropertyChanged += CarOwnerViewModel_PropertyChanged;
        }

        public int ID { get
            {
                return carOwner.ID;
            } 
        }

        public void Save()
        {
            if (changed)
            {
                int id = carOwner.ID;
                AutoServiceModel_HttpRequests.AddCarOwner(carOwner);
                if (id == 0)
                {
                    var cos = AutoServiceModel_HttpRequests.GetCarOwners();
                    var max = cos.Max(p => p.ID);
                    carOwner = cos.First(p => p.ID == max);
                    OnPropertyChanged(nameof(ID));
                }
                changed = false;
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
