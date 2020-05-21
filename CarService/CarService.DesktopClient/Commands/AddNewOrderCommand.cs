using CarService.DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace CarService.DesktopClient.Commands
{
    public class AddNewOrderCommand : ICommand
    {
        private IndexOrderViewModel IndexOrderViewModel;
        public AddNewOrderCommand(IndexOrderViewModel indexOrderViewModel)
        {
            this.IndexOrderViewModel = indexOrderViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IndexOrderViewModel.AddNewOrder();
            IndexOrderViewModel.OpenOrderForm();
        }
    }
}
