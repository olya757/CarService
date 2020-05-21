using CarService.DesktopClient.ViewModel;
using CarService.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CarService.DesktopClient.Model;
using CarService.DataAccess.DTO;

namespace CarService.DesktopClient.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private static void GenerateDataForModel(int codePhone)
        //{
        //    List<string> names = new List<string>() { "Michael", "Ivan", "Olga", "Dmitriy", "Alexandr", "John" };
        //    List<string> surnames = new List<string>() { "Ryzhenko", "Geitz", "Frey", "Green", "Brown", "Ivanko" };
        //    List<string> carmodels = new List<string>() { "Kalina", "Benz", "Octavia", "Granta", "Pajero", "Cayenne" };
        //    List<string> carmarks = new List<string>() { "Lada", "Mercedes", "Skoda", "Porsche", "Mitsubishi", "Audi" };
        //    List<string> namesOfWork = new List<string>() { "Починка двигателя", "Замена масла", "Замена резины", "Покраска кузова", "Замена ремня", "Замена свечей зажигания" };

        //    Random random = new Random();


        //    List<CarOwnerDTO> carOwners = new List<CarOwnerDTO>();
        //    carOwners = AutoServiceModel_HttpRequests.GetCarOwners();
        //    foreach (var co in carOwners)
        //    {
        //        AutoServiceModel_HttpRequests.DeleteCarOwner(co.ID);
        //    }

        //    carOwners = new List<CarOwnerDTO>();
        //    for (int i = 0; i <= 30; i++)
        //    {
        //        CarOwnerDTO carOwner = new CarOwnerDTO();
        //        carOwner.Name = names[random.Next(0, names.Count())];
        //        carOwner.Surname = surnames[random.Next(0, surnames.Count())];
        //        carOwner.SecondName = names[random.Next(0, names.Count())];
        //        carOwner.Phone = "+7(" + codePhone.ToString() + ")-000-" + (1000 + i).ToString();
        //        carOwner.Birthday = new DateTime(random.Next(1900, 2019), random.Next(1, 13), random.Next(1, 28));
        //        carOwners.Add(carOwner);
        //    }

        //    foreach (var co in carOwners)
        //    {
        //        AutoServiceModel_HttpRequests.AddCarOwner(co);
        //    }

        //    carOwners = AutoServiceModel_HttpRequests.GetCarOwners();

        //    for (int i = 0; i <= 50; i++)
        //    {
        //        OrderDTO order = new OrderDTO();
        //        order.CarBrand = carmarks[random.Next(0, carmarks.Count())];
        //        order.CarModel = carmodels[random.Next(0, carmodels.Count())];
        //        order.NameOfWorks = namesOfWork[random.Next(0, namesOfWork.Count())];
        //        order.YearOfManufacture = random.Next(1990, 2020);
        //        order.TypeOfTransmission = (TypeOfTransmission)random.Next(0, 3);
        //        order.EnginePower = random.Next(20, 300);
        //        order.DateOfStart = new DateTime(random.Next(2012, 2021), random.Next(1, 13), random.Next(1, 28));
        //        order.DateOfFinish = random.Next(0, 5) == 0 ? order.DateOfStart.AddHours(-1) : (order.DateOfStart.AddHours(random.Next(1, 100)));
        //        order.Price = random.Next(1, 500) * 1000;
        //        order.OwnerID = carOwners[random.Next(0, carOwners.Count())].ID;
        //        AutoServiceModel_HttpRequests.AddOrder(order);
        //    }
        //}


    }
}
