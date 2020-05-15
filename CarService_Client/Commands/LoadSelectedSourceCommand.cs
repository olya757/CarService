using CarService_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService_Client.Commands
{
    public class LoadSelectedSourceCommand : ICommand
    {
        private SourceManagerViewModel sourceManagerViewModel;
        public LoadSelectedSourceCommand(SourceManagerViewModel sourceManagerViewModel)
        {
            this.sourceManagerViewModel = sourceManagerViewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return sourceManagerViewModel.CanLoad;
        }

        public void Execute(object parameter)
        {
            sourceManagerViewModel.LoadSelectedOrders();
        }
    }
}
