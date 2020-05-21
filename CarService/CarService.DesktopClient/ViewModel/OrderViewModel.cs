using CarService.DataAccess.DTO;
using CarService.DataAccess.Model;
using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Model;
using CarService.DesktopClient.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CarService.DesktopClient.ViewModel
{
    public class OrderViewModel : ViewModel
    {
        private OrderDTO order;

        public OrderViewModel()
        {
            this.order = new OrderDTO
            {
                YearOfManufacture = 1990,
                DateOfStart = DateTime.Now,
                DateOfFinish = DateTime.Now
            };
            NeedToSave = true;
            Init();
        }

        public OrderViewModel(OrderDTO order)
        {
            this.order = order;
            NeedToSave = false;
            Init();
        }

        public OpenOrderFormCommand OpenOrderFormCommand { get; set; }

        public List<string> TypesOfTransmission { get; set; }

        public void Init()
        {
            TypesOfTransmission = new List<string>();
            TypesOfTransmission.Add("Передний привод");
            TypesOfTransmission.Add("Задний привод");
            TypesOfTransmission.Add("Полный привод");
            OpenOrderFormCommand = new OpenOrderFormCommand(this);
            MouseDoubleClickCommand = new RelayCommand<OrderViewModel>(
                item =>
                {
                    item.OpenOrderForm();
                });
            

            this.PropertyChanged += OrderViewModel_PropertyChanged;
        }

        public bool NeedToSave { get; set; }

        private void OrderViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NeedToSave = true;
        }

        public void Save()
        {
            if (NeedToSave)
            {
                var id = order.ID;
                AutoServiceModel_HttpRequests.AddOrder(order);
                //чтобы получить правильный ID
                if (id == 0)
                {
                    var cos = AutoServiceModel_HttpRequests.GetOrders();
                    var max = cos.Max(p => p.ID);
                    order = cos.First(p => p.ID == max);
                    OnPropertyChanged(nameof(ID));
                }
                NeedToSave = false;
            }
        }

        public void Delete()
        {
            AutoServiceModel_HttpRequests.DeleteOrder(order.ID);
            NeedToSave = false;
        }

        public int ID
        {
            get
            {
                return order.ID;
            }
        }

        public int OwnerID
        {
            get
            {
                return order.OwnerID;
            }
            set
            {
                order.OwnerID = value;
                OnPropertyChanged(nameof(OwnerID));
            }
        }

        public DateTime DateOfStart
        {
            get
            {
                return order.DateOfStart;
            }
            set
            {
                if (value.Year > 1990)
                {
                    order.DateOfStart = value;
                    if (DateOfFinish < value)
                    {
                        DateOfFinish = value;
                    }
                    OnPropertyChanged(nameof(DateOfStart));
                }
            }
        }

        public DateTime DateOfFinish
        {
            get
            {
                return order.DateOfFinish;
            }
            set
            {
                if (value >= DateOfStart)
                {
                    order.DateOfFinish = value;
                }
                OnPropertyChanged(nameof(DateOfFinish));
            }
        }

        public string CarBrand
        {
            get
            {
                return order.CarBrand;
            }
            set
            {
                order.CarBrand = value;
                OnPropertyChanged(nameof(CarBrand));
            }
        }

        public string CarModel
        {
            get
            {
                return order.CarModel;
            }
            set
            {
                order.CarModel = value;
                OnPropertyChanged(nameof(CarModel));
            }
        }

        public int YearOfManufacture
        {
            get
            {
                return order.YearOfManufacture;
            }
            set
            {
                if (value<=DateTime.Now.Year && value > 1900)
                {
                    order.YearOfManufacture = value;
                }
                OnPropertyChanged(nameof(YearOfManufacture));
                
            }
        }

        public string TypeOfTransmission
        {
            get
            {
                return TypesOfTransmission[(int)order.TypeOfTransmission];
            }
            set
            {
                order.TypeOfTransmission = (TypeOfTransmission)TypesOfTransmission.IndexOf(value);
                OnPropertyChanged(nameof(TypeOfTransmission));
            }
        }

        public double EnginePower
        {
            get
            {
                return order.EnginePower;
            }
            set
            {
                if (value >= 0)
                {
                    order.EnginePower = value;
                    OnPropertyChanged(nameof(EnginePower));
                }
            }
        }
        public string NameOfWorks
        {
            get
            {
                return order.NameOfWorks;
            }
            set
            {
                order.NameOfWorks = value;
                OnPropertyChanged(nameof(NameOfWorks));
            }
        }
        public int Price
        {
            get
            {
                return order.Price;
            }
            set
            {
                if (value >= 0)
                {
                    order.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public OrderFormViewModel OrderFormViewModel
        {
            get
            {
                return new OrderFormViewModel(this);
            }
        }
        public void OpenOrderForm()
        {
            OrderFormWindow orderFormWindow = new OrderFormWindow();
            orderFormWindow.DataContext = OrderFormViewModel;
            orderFormWindow.ShowDialog();
        }

        public ICommand MouseDoubleClickCommand{ get;set;}

    }
}
