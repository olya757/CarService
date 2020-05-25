using CarService.DesktopClient.Commands;
using System.Collections.ObjectModel;
using CarService.DesktopClient.Helpers;
using System;

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
        public IndexCarOwnerViewModel(bool createEmpty=false)
        {
            CarOwners = new ObservableCollection<CarOwnerViewModel>();
            try
            {
                if (!createEmpty)
                {
                    foreach (var co in AutoServiceRequestsHelper.GetCarOwners())
                    {
                        var owner = new CarOwnerViewModel(co);
                        owner.PropertyChanged += Owner_PropertyChanged;
                        CarOwners.Add(owner);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                AddCarOwnerCommand = new AddCarOwnerCommand(this);
            }
        }

        public AddCarOwnerCommand AddCarOwnerCommand { get; set; }

        private void Owner_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged("CarOwners");
        }

        public void AddCarOwner()
        {            
            var carOwner = new CarOwnerViewModel();
            CarOwners.Add(carOwner);
            CurrentOwner = carOwner;
        }

        public void Save()
        {
            try
            {
                foreach (var co in CarOwners)
                {
                    co.Save();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
