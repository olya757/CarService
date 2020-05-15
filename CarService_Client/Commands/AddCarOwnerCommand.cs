using CarService_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService_Client.Commands
{
    public class AddCarOwnerCommand : ICommand
    {
        private IndexCarOwnerViewModel indexCarOwnerViewModel;

        public AddCarOwnerCommand(IndexCarOwnerViewModel indexCarOwnerViewModel)
        {
            this.indexCarOwnerViewModel = indexCarOwnerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            indexCarOwnerViewModel.AddCarOwner();
        }
    }
}
