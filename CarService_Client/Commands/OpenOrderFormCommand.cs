using CarService_Client.ViewModel;
using System;
using System.Windows.Input;

namespace CarService_Client.Commands
{
    public class OpenOrderFormCommand : ICommand
    {
        private IndexOrderViewModel indexOrderViewModel;
        public OpenOrderFormCommand(IndexOrderViewModel indexOrderViewModel)
        {
            this.indexOrderViewModel = indexOrderViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            indexOrderViewModel.OpenOrderForm();
        }
    }
}
