using CarService.DesktopClient.Commands;
using CarService.DataAccess.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CarService.DesktopClient.Model;

namespace CarService.DesktopClient.ViewModel
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
        public IndexCarOwnerViewModel()
        {
            CarOwners = new ObservableCollection<CarOwnerViewModel>();
            foreach(var co in AutoServiceModel_HttpRequests.GetCarOwners())
            {
                var owner =new CarOwnerViewModel(co);
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
            var carOwner = new CarOwnerViewModel();
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
