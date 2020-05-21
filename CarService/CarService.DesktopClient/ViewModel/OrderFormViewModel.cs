using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CarService.DesktopClient.ViewModel
{
    public class OrderFormViewModel:ViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public IndexCarOwnerViewModel IndexCarOwnerViewModel { get; set; }

        public OrderFormViewModel(OrderViewModel order)
        {
            OrderViewModel = order;
            IndexCarOwnerViewModel = new IndexCarOwnerViewModel();
            if (IndexCarOwnerViewModel.CarOwners.Any(p => p.ID == order.OwnerID))
            {
                IndexCarOwnerViewModel.CurrentOwner = IndexCarOwnerViewModel.CarOwners.First(p => p.ID == OrderViewModel.OwnerID);
            }
            else
            {
                IndexCarOwnerViewModel.CurrentOwner = new CarOwnerViewModel();
            }
            SaveNewOrderCommand = new RelayCommand<Window>(this.Save);
        }

        public ICommand SaveNewOrderCommand { get; set; }

        public void Save(Window window)
        {
            IndexCarOwnerViewModel.Save();
            //IndexCarOwnerViewModel.CurrentOwner.Save();
            OrderViewModel.OwnerID = IndexCarOwnerViewModel.CurrentOwner.ID;
            OrderViewModel.Save();
            window.Close();
        }

        
    }
}
