using CarService.DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace CarService.DesktopClient.Commands
{
    public class DeleteOrderCommand : ICommand
    {
        private IndexOrderViewModel IndexOrderViewModel;
        public DeleteOrderCommand(IndexOrderViewModel indexOrderViewModel)
        {
            IndexOrderViewModel = indexOrderViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return !(IndexOrderViewModel.CurrentOrder is null);
        }

        public void Execute(object parameter)
        {
            IndexOrderViewModel.DeleteOrder();
        }
    }
}
