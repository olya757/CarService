using CarService_Client.Commands;
using CarService_Client.Model;
using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.ViewModel
{
    public class IndexCarOwnerViewModel:ViewModel
    {
        public ObservableCollection<CarOwnerViewModel> CarOwners { get; set; }

        private CarOwnerViewModel currentOwner;
        public CarOwnerViewModel CurrentOwner
        {
            get
            {
                return currentOwner;
            }
            set
            {
                currentOwner = value;
                OnPropertyChanged(nameof(CurrentOwner));

            }
        }
        public IndexCarOwnerViewModel(List<CarOwner> carOwners, IAutoServiceModel autoServiceModel):base(autoServiceModel)
        {
            CarOwners = new ObservableCollection<CarOwnerViewModel>();
            foreach(var co in carOwners)
            {
                var owner =new CarOwnerViewModel(co, autoServiceModel);
                owner.PropertyChanged += Owner_PropertyChanged;
                CarOwners.Add(owner);
            }
            AddCarOwnerCommand = new AddCarOwnerCommand(this);
        }

        public AddCarOwnerCommand AddCarOwnerCommand { get; set; }

        private void Owner_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged("CarOwners");
        }

        public void AddCarOwner()
        {            
            var carOwner = new CarOwnerViewModel(AutoServiceModel);
            //carOwner.Save();
            CarOwners.Add(carOwner);
            CurrentOwner = carOwner;
        }

        public void Save()
        {
            foreach(var co in CarOwners)
            {
                co.Save();
            }
        }
    }
}
