using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Model;
using CarService.DesktopClient.View;
using DevExpress.Mvvm;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Expression.Interactivity.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace CarService.DesktopClient.ViewModel
{
    public class IndexOrderViewModel : ViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        
        public OrderFormViewModel OrderFormViewModel{
            get
            {
                return new OrderFormViewModel(CurrentOrder);
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

        public IndexOrderViewModel()
        {
            
            Orders = new ObservableCollection<OrderViewModel>();
            foreach(var o in AutoServiceModel_HttpRequests.GetOrders())
            {
                var order = new OrderViewModel(o);
                order.PropertyChanged += Order_PropertyChanged;
                Orders.Add(order);
            }
            if(Orders.Count()>0)
                CurrentOrder = Orders.First();
            AddNewOrderCommand = new AddNewOrderCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);

            MouseDoubleClickCommand = new DelegateCommand<OrderViewModel>(item=> item.OpenOrderForm());
        }

        public void Update()
        {
            
            Orders = new ObservableCollection<OrderViewModel>();
            foreach (var o in AutoServiceModel_HttpRequests.GetOrders())
            {
                var order = new OrderViewModel(o);
                order.PropertyChanged += Order_PropertyChanged;
                Orders.Add(order);
            }
            if (Orders.Count() > 0)
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
            var ordervm = new OrderViewModel();
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

        public void OpenOrderForm(object row)
        {
            OrderFormWindow orderFormWindow = new OrderFormWindow();
            orderFormWindow.DataContext = OrderFormViewModel;
            if(!(orderFormWindow.ShowDialog() is true))
            {
                if (CurrentOrder.ID == 0)
                {
                    Orders.Remove(CurrentOrder);
                }               
            }
        }
        public ICommand MouseDoubleClickCommand { get; private set; }

    }
}
