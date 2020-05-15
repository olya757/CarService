using CarService_Client.Commands;
using CarService_Client.Model;
using CarService_Client.View;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarService_Client.ViewModel
{
    public class IndexOrderViewModel : ViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        private IndexCarOwnerViewModel IndexCarOwnerViewModel;

        public OrderFormViewModel OrderFormViewModel{
            get
            {
                return new OrderFormViewModel(CurrentOrder, IndexCarOwnerViewModel, AutoServiceModel);
            }
        }

        private OrderViewModel currentOrder;
        public OrderViewModel CurrentOrder
        {
            get
            {
                return currentOrder;
            }
            set
            {
                currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }
        private IAutoServiceModel autoServiceModel;
        public IndexOrderViewModel(IAutoServiceModel autoServiceModel):base(autoServiceModel)
        {
            IndexCarOwnerViewModel = new IndexCarOwnerViewModel(autoServiceModel.GetCarOwners(),autoServiceModel);
            
            Orders = new ObservableCollection<OrderViewModel>();
            foreach(var o in autoServiceModel.GetOrders())
            {
                var order = new OrderViewModel(o, AutoServiceModel);
                order.PropertyChanged += Order_PropertyChanged;
                Orders.Add(order);
            }
            if(Orders.Count()>0)
                CurrentOrder = Orders.First();
            AddNewOrderCommand = new AddNewOrderCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);
        }

        public AddNewOrderCommand AddNewOrderCommand { get; set; }

        public DeleteOrderCommand DeleteOrderCommand { get; set; }

        private void Order_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Orders");
        }

        public void AddNewOrder()
        {
            var ordervm = new OrderViewModel(AutoServiceModel);
            Orders.Add(ordervm);
            CurrentOrder = ordervm;
        }

        public void DeleteOrder()
        {
            if (!(CurrentOrder is null))
            {
                CurrentOrder.Delete();
                Orders.Remove(CurrentOrder);
                CurrentOrder = null;
            }
            if(Orders.Count()>0)
            CurrentOrder = Orders.Last();
        }

        public void Save()
        {
            foreach(var o in Orders)
            {
                o.Save();
            }
        }

        public void OpenOrderForm()
        {
            OrderFormWindow orderFormWindow = new OrderFormWindow();
            orderFormWindow.DataContext = OrderFormViewModel;
            if(orderFormWindow.ShowDialog() is true)
            {

            }
            else
            {
                if (CurrentOrder.ID == 0)
                {
                    Orders.Remove(CurrentOrder);
                }               
            }
        }
    }
}
