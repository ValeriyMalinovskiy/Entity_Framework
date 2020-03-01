using _2020._03._01_Bike_Repository.Command.BicycleStore.Command;
using _2020._03._01_Bike_Repository.DAL.Model;
using _2020._03._01_Bike_Repository.DAL.Model.Enums.BicycleStore.Model.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace _2020._03._01_Bike_Repository.ViewModel
{
    class BicycleShopViewModel : INotifyPropertyChanged
    {
        private Bicycle selectedBicycle;

        private ObservableCollection<Bicycle> bicycleCollection;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RemoveBicycleCommand { get; set; }

        public ICommand SetDefaultsCommand { get; set; }

        public BicycleShopViewModel()
        {
            this.bicycleCollection = new ObservableCollection<Bicycle>{
                 new Bicycle ( "Pride", "Donut 6.2", 300, Country.Ukraine, FrameSize.XL, 2019 ),
                new Bicycle("Cannondale", "Habit 6", 1500, Country.USA, FrameSize.S, 2018),
               new Bicycle("Apollo", "Aspire 10", 500, Country.Australia, FrameSize.XL, 2015),
                 new Bicycle("Apollo", "Aspire 20", 570, Country.Australia, FrameSize.S, 2020),
                 new Bicycle("Apollo", "Aspire 30", 650, Country.Australia, FrameSize.S, 2019),
                new Bicycle("Apollo", "Aspire 40", 700, Country.Australia, FrameSize.M, 2017),
                new Bicycle("Haibike", "Seet HardNine 2.0", 400, Country.Germany, FrameSize.M, 2020),
                new Bicycle("Pride", "Push 2.0", 100, Country.Ukraine, FrameSize.NA, 2017)
            };
            this.RemoveBicycleCommand = new RelayCommand(RemoveBicycleCommandExecuted, CommandCanExecute);
            this.SetDefaultsCommand = new RelayCommand(SetDefaultsCommandExecuted, CommandCanExecute);
        }

        public Bicycle SelectedBicycle
        {
            get
            {
                return this.selectedBicycle;
            }
            set
            {
                if (value != this.selectedBicycle)
                {
                    this.selectedBicycle = value;
                    OnPropertyChanged(nameof(this.selectedBicycle));
                }
            }
        }

        public ObservableCollection<Bicycle> BicycleCollection
        {
            get
            {
                return this.bicycleCollection;
            }
            set
            {
                if (value != this.bicycleCollection)
                {
                    this.bicycleCollection = value;
                    OnPropertyChanged(nameof(this.bicycleCollection));
                }
            }
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool CommandCanExecute(object obj)
        {
            if (this.SelectedBicycle == null)
            {
                return false;
            }
            return true;
        }

        private void RemoveBicycleCommandExecuted(object obj)
        {
            this.BicycleCollection.Remove(this.SelectedBicycle);
        }

        private void SetDefaultsCommandExecuted(object obj)
        {
            this.SelectedBicycle.Brand = "Brand";
            this.SelectedBicycle.BicycleFrameSize = null;
            this.SelectedBicycle.Model = "Model";
            this.SelectedBicycle.OriginCountry = null;
            this.SelectedBicycle.Price = 0;
            this.SelectedBicycle.Year = 0;
        }
    }
}
