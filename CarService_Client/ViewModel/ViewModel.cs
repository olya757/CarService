using CarService_Client.Model;
using System;
using System.ComponentModel;
using System.Windows;

namespace CarService_Client.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        protected IAutoServiceModel AutoServiceModel { get; set; }

        public ViewModel(IAutoServiceModel autoServiceModel)
        {
            this.AutoServiceModel = autoServiceModel;
        }

        public ViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            try
            {

                if (!(PropertyChanged is null) && !(prop is null))
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
