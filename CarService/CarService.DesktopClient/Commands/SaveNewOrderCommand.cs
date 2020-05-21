using CarService.DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace CarService.DesktopClient.Commands
{
    public class SaveNewOrderCommand : ICommand
    {
        private OrderFormViewModel OrderFormViewModel;
        public SaveNewOrderCommand(OrderFormViewModel orderFormViewModel)
        {
            this.OrderFormViewModel = orderFormViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OrderFormViewModel.Save();
        }
    }
}
