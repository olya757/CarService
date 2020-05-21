using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Model;
using CarService.DesktopClient.View;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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
            try
            {
                Orders = new ObservableCollection<OrderViewModel>();
                foreach (var o in AutoServiceModel_HttpRequests.GetOrders())
                {
                    var order = new OrderViewModel(o);
                    Orders.Add(order);
                }
                if (Orders.Count() > 0)
                    CurrentOrder = Orders.First();
                AddNewOrderCommand = new AddNewOrderCommand(this);
                DeleteOrderCommand = new DeleteOrderCommand(this);

                MouseDoubleClickCommand = new RelayCommand<object>(
                    item =>
                    {
                        CurrentOrder.OpenOrderForm();
                    });

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public void Update()
        {
            try
            {
                Orders = new ObservableCollection<OrderViewModel>();
                foreach (var o in AutoServiceModel_HttpRequests.GetOrders())
                {
                    var order = new OrderViewModel(o);
                    Orders.Add(order);
                }
                if (Orders.Count() > 0)
                    CurrentOrder = Orders.First();
                AddNewOrderCommand = new AddNewOrderCommand(this);
                DeleteOrderCommand = new DeleteOrderCommand(this);
            }
            catch(Exception e)
            {
                throw new System.Exception(e.Message);
            }

        }

        public bool NeedToSave { get
            {
                return Orders.Any(o => o.NeedToSave);
            }
        }

        public AddNewOrderCommand AddNewOrderCommand { get; set; }

        public DeleteOrderCommand DeleteOrderCommand { get; set; }

     

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

        public void OpenOrderForm()
        {
            OrderFormWindow orderFormWindow = new OrderFormWindow();
            orderFormWindow.DataContext = OrderFormViewModel;
            if(!(orderFormWindow.ShowDialog() is true))
            {
                if (CurrentOrder.ID == 0)
                {
                    Orders.Remove(CurrentOrder);
                    if (Orders.Count() > 0)
                    {
                        CurrentOrder = Orders.First();
                    }
                    else
                    {
                        CurrentOrder = null;
                    }
                }               
            }
        }
        public ICommand MouseDoubleClickCommand { get; private set; }

    }
}
