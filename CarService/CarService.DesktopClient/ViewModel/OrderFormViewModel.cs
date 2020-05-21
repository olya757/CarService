using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Model;
using System.Linq;

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
            SaveNewOrderCommand = new SaveNewOrderCommand(this);
        }

        public SaveNewOrderCommand SaveNewOrderCommand { get; set; }

        public void Save()
        {
            IndexCarOwnerViewModel.Save();
            //IndexCarOwnerViewModel.CurrentOwner.Save();
            OrderViewModel.OwnerID = IndexCarOwnerViewModel.CurrentOwner.ID;
            OrderViewModel.Save();
        }
    }
}
