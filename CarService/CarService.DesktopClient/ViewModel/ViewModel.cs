using System;
using System.ComponentModel;
using System.Windows;

namespace CarService.DesktopClient.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        protected static int source = 1;

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
