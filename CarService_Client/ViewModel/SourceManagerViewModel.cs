using CarService_Client.Commands;
using CarService_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.ViewModel
{
    public class SourceManagerViewModel:ViewModel
    {
        public List<string> Sources { get; set; }

        public Dictionary<string, IAutoServiceModel> SourcesDict { get; set; }

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
            SourcesDict = new Dictionary<string, IAutoServiceModel>();
            SourcesDict[Sources[0]] = new AutoServiceModelFromDB();
            SourcesDict[Sources[1]] =FileDataAccessCreator.GetFileDataAccess(@"../../Data/AutoServiceData.xml").GetModel();
            SourcesDict[Sources[2]] = FileDataAccessCreator.GetFileDataAccess(@"../../Data/AutoServiceData.dat").GetModel();
            CurrentSource = Sources[0];
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
            LoadedSource = CurrentSource;
            IndexOrderViewModel = new IndexOrderViewModel(SourcesDict[CurrentSource]);
            OnPropertyChanged(nameof(IndexOrderViewModel));
        }
    }
}
