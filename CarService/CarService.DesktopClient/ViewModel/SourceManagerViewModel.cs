using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Model;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CarService.DesktopClient.ViewModel
{
    public class SourceManagerViewModel:ViewModel
    {
        public enum DataSourceType
        {
            db,
            xml,
            dat
        }
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
            AutoServiceModel_HttpRequests.UpdateSource(SourcesDict[CurrentSource]);

            IndexOrderViewModel = new IndexOrderViewModel();
            LoadSelectedSourceCommand = new LoadSelectedSourceCommand(this);
            WindowClosingCommand = new RelayCommand(this.SaveChanges);
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
            try
            {
                AutoServiceModel_HttpRequests.UpdateSource(SourcesDict[CurrentSource]);
                SaveChanges();
                IndexOrderViewModel.Update();
                LoadedSource = CurrentSource;

                OnPropertyChanged(nameof(IndexOrderViewModel));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SaveChanges()
        {
            if (IndexOrderViewModel.NeedToSave)
            {
                if (MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Сохранить изменения", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    IndexOrderViewModel.Save();
                }
            }
        }

        public ICommand WindowClosingCommand { get; set; }
    }
}
