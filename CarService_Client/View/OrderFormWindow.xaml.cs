using System.Windows;

namespace CarService_Client.View
{
    /// <summary>
    /// Логика взаимодействия для OrderFormWindow.xaml
    /// </summary>
    public partial class OrderFormWindow : Window
    {
        public OrderFormWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
