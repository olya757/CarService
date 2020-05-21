using CarService.DesktopClient.Commands;
using CarService.DesktopClient.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CarService.DesktopClient.ViewModel
{
    public class SourceManagerViewModel:ViewModel
    {
        public List<string> Sources { get; set; }

        public Dictionary<string, int> SourcesDict { get; set; }

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
            SourcesDict = new Dictionary<string, int>();
            SourcesDict[Sources[0]] = 1;
            SourcesDict[Sources[1]] = 2;
            SourcesDict[Sources[2]] = 3;
            CurrentSource = Sources[0];
            AutoServiceModel_HttpRequests.UpdateSource(SourcesDict[CurrentSource]);

            IndexOrderViewModel = new IndexOrderViewModel();
            LoadSelectedSourceCommand = new LoadSelectedSourceCommand(this);
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
                IndexOrderViewModel.Update();
                LoadedSource = CurrentSource;

                OnPropertyChanged(nameof(IndexOrderViewModel));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
