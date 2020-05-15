using CarService_Client.Model;
using CarService_Client.ViewModel;
using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarService_Client.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CreateData();
        }

        private static void CreateData()
        {
            //AutoServiceModelFromDB autoServiceModel_db = new AutoServiceModelFromDB();
            //GenerateDataForModel(autoServiceModel_db,960);

            //var fileDataAccess_dat = FileDataAccessCreator.GetFileDataAccess(@"../../Data/AutoServiceData.dat");
            //AutoServiceModel autoServiceModel_dat = fileDataAccess_dat.GetModel();
            //GenerateDataForModel(autoServiceModel_dat,905);

            var fileDataAccess_xml = FileDataAccessCreator.GetFileDataAccess(@"../../Data/AutoServiceData.xml");
            AutoServiceModel autoServiceModel_xml = fileDataAccess_xml.GetModel();
            GenerateDataForModel(autoServiceModel_xml,920);
        }


        private static  void GenerateDataForModel(IAutoServiceModel autoServiceModel, int codePhone)
        {
            List<string> names = new List<string>() { "Michael", "Ivan", "Olga", "Dmitriy", "Alexandr", "John" };
            List<string> surnames = new List<string>() { "Ryzhenko", "Geitz", "Frey", "Green", "Brown", "Ivanko" };
            List<string> carmodels = new List<string>() { "Kalina", "Benz", "Octavia", "Granta", "Pajero", "Cayenne" };
            List<string> carmarks = new List<string>() { "Lada", "Mercedes", "Skoda", "Porsche", "Mitsubishi", "Audi" };
            List<string> namesOfWork = new List<string>() { "Починка двигателя", "Замена масла", "Замена резины", "Покраска кузова", "Замена ремня", "Замена свечей зажигания" };

            Random random = new Random();

            
            List<CarOwner> carOwners = new List<CarOwner>();
            carOwners = autoServiceModel.GetCarOwners();
            foreach(var co in carOwners)
            {
                autoServiceModel.DeleteCarOwner(co.ID);
            }

            carOwners = new List<CarOwner>();
            for (int i = 0; i <= 30; i++)
            {
                CarOwner carOwner = new CarOwner();
                carOwner.Name = names[random.Next(0, names.Count())];
                carOwner.Surname = surnames[random.Next(0, surnames.Count())];
                carOwner.SecondName = names[random.Next(0, names.Count())];
                carOwner.Phone = "+7("+codePhone.ToString()+")-000-"+(1000+i).ToString();
                carOwner.Birthday = new DateTime(random.Next(1900, 2019), random.Next(1, 13), random.Next(1, 28));
                carOwners.Add(carOwner);
            }

            foreach(var co in carOwners)
            {
                autoServiceModel.AddCarOwner(co);
            }

            carOwners = autoServiceModel.GetCarOwners();

            for (int i = 0; i <= 50; i++)
            {
                Order order = new Order();
                order.CarBrand = carmarks[random.Next(0, carmarks.Count())];
                order.CarModel = carmodels[random.Next(0, carmodels.Count())];
                order.NameOfWorks = namesOfWork[random.Next(0, namesOfWork.Count())];
                order.YearOfManufacture = random.Next(1990, 2020);
                order.TypeOfTransmission = (TypeOfTransmission)random.Next(0, 3);
                order.EnginePower = random.Next(20, 300);
                order.DateOfStart = new DateTime(random.Next(2012, 2021), random.Next(1, 13), random.Next(1, 28));
                order.DateOfFinish = random.Next(0, 5) == 0 ? order.DateOfStart.AddHours(-1) : (order.DateOfStart.AddHours(random.Next(1, 100)));
                order.Price = random.Next(1, 500) * 1000;
                order.OwnerID = carOwners[random.Next(0, carOwners.Count())].ID;
                autoServiceModel.AddOrder(order);
            }            
        }

        private void dgOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((SourceManagerViewModel)this.DataContext).IndexOrderViewModel.OpenOrderForm();
        }
    }
}
