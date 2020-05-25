using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Helpers;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CarService.DesktopClient.ViewModel
{
    public class SourceManagerViewModel:ViewModel
    {       
        public List<string> Sources { get; set; }

        public Dictionary<string, DataSourceType> SourcesDict { get; set; }

        private string LoadedSource;
        private string currentSource;

        public string CurrentSource { 
            get
            {
                return currentSource;
            }
            set
            {
                currentSource = value;
                OnPropertyChanged(nameof(CurrentSource));
                OnPropertyChanged(nameof(CanLoad));
            }
        }

        public IndexOrderViewModel IndexOrderViewModel { get; set; }

        public SourceManagerViewModel()
        {
            Sources = new List<string>();
            Sources.Add("CarServiceDB");
            Sources.Add("AutoServiceData.xml");
            Sources.Add("AutoServiceData.dat");
            SourcesDict = new Dictionary<string, DataSourceType>();
            SourcesDict[Sources[0]] = DataSourceType.db;
            SourcesDict[Sources[1]] = DataSourceType.xml;
            SourcesDict[Sources[2]] = DataSourceType.dat;
            CurrentSource = Sources[0];

            AutoServiceRequestsHelper.UpdateSource(SourcesDict[CurrentSource]);
           
            LoadSelectedSourceCommand = new LoadSelectedSourceCommand(this);
            WindowClosingCommand = new RelayCommand(this.SaveChanges);
            OnPropertyChanged(nameof(IndexOrderViewModel));

        }

        public LoadSelectedSourceCommand LoadSelectedSourceCommand { get; set; }

        public bool CanLoad
        {
            get
            {
                return LoadedSource != CurrentSource;
            }
        }

        public void LoadSelectedOrders()
        {   
            SaveChanges();
            AutoServiceRequestsHelper.UpdateSource(SourcesDict[CurrentSource]);
            if (IndexOrderViewModel is null)
            {
                try
                {
                    IndexOrderViewModel = new IndexOrderViewModel();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    IndexOrderViewModel = new IndexOrderViewModel(true);
                }
            }
            else
            {
                try
                {
                    IndexOrderViewModel.Update();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    IndexOrderViewModel.Update(true);
                }

            }
            LoadedSource = CurrentSource;

            OnPropertyChanged(nameof(IndexOrderViewModel));
          
        }

        public void SaveChanges()
        {
            if (!(IndexOrderViewModel is null) &&  IndexOrderViewModel.NeedToSave)
            {
                if (MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Сохранить изменения", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        IndexOrderViewModel.Save();
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        public ICommand WindowClosingCommand { get; set; }
    }
}
