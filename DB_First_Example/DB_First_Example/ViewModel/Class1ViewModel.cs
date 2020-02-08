using DB_First_Example.Models;
using Microsoft.EntityFrameworkCore;
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
                DbSet<Product> tempDBSet = context.Product;
                this.DBProducts = new ObservableCollection<Product>();
                foreach (var item in tempDBSet)
                {
                    DBProducts.Add(item);
                }
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
