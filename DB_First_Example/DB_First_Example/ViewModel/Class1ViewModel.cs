using DB_First_Example.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DB_First_Example.ViewModel
{
    class Class1ViewModel : INotifyPropertyChanged
    {
        public Class1ViewModel()
        {
            using (var context = new ZzaContext())
            {
                DBProducts = new ObservableCollection<Product>(context.Product);
            }
        }

        private ObservableCollection<Product> dBProducts { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> DBProducts
        {
            get
            {
                return dBProducts;
            }
            set
            {
                if (value != dBProducts)
                {
                    dBProducts = value;
                    OnPropertyChanged(nameof(dBProducts));
                }
            }
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
