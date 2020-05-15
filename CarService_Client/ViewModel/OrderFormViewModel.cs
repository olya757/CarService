using CarService_Client.Commands;
using CarService_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.ViewModel
{
    public class OrderFormViewModel:ViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public IndexCarOwnerViewModel IndexCarOwnerViewModel { get; set; }

        public OrderFormViewModel(OrderViewModel order, IndexCarOwnerViewModel indexCarOwnerViewModel, IAutoServiceModel autoServiceModel):base(autoServiceModel)
        {
            OrderViewModel = order;
            IndexCarOwnerViewModel = indexCarOwnerViewModel;
            if (IndexCarOwnerViewModel.CarOwners.Any(p => p.ID == order.OwnerID))
            {
                IndexCarOwnerViewModel.CurrentOwner = IndexCarOwnerViewModel.CarOwners.First(p => p.ID == OrderViewModel.OwnerID);
            }
            else
            {
                IndexCarOwnerViewModel.CurrentOwner = new CarOwnerViewModel(AutoServiceModel);
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
