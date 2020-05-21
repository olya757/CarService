using CarService.DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace CarService.DesktopClient.Commands
{
    public class AddCarOwnerCommand : ICommand
    {
        private IndexCarOwnerViewModel indexCarOwnerViewModel;

        public AddCarOwnerCommand(IndexCarOwnerViewModel indexCarOwnerViewModel)
        {
            this.indexCarOwnerViewModel = indexCarOwnerViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return !(indexCarOwnerViewModel is null);
        }

        public void Execute(object parameter)
        {
            indexCarOwnerViewModel.AddCarOwner();
        }
    }
}
