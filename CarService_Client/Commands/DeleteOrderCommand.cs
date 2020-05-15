using CarService_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService_Client.Commands
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
