using CarService.DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace CarService.DesktopClient.Commands
{
    public class OpenOrderFormCommand : ICommand
    {
        private OrderViewModel orderViewModel;
        public OpenOrderFormCommand(OrderViewModel orderViewModel)
        {
            this.orderViewModel = orderViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            orderViewModel.OpenOrderForm();
        }
    }
}
