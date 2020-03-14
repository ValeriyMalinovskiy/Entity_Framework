using _2020._03._01_Bike_Repository.DAL.Model.Enums;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace _2020._03._01_Bike_Repository.DAL.Model
{
    public class Bicycle : INotifyPropertyChanged
    {
        private string brand;

        private string model;

        private readonly ImagePathHelper helper = new ImagePathHelper();

        private BitmapImage image;

        private decimal price;

        private Country? originCountry;

        private FrameSize? bicycleFrameSize;

        private int year;

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                if (value != this.brand)
                {
                    this.brand = value;
                    OnPropertyChanged(nameof(this.brand));
                }
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value != this.model)
                {
                    this.model = value;
                    this.Image = this.helper.GetImageByModel(value);
                }
                OnPropertyChanged(nameof(this.model));
            }
        }

        public BitmapImage Image
        {
            get
            {
                return this.image;
            }
            private set
            {
                if (value != this.image)
                {
                    this.image = value;
                    OnPropertyChanged(nameof(this.image));
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value != this.price)
                {
                    this.price = value;
                    OnPropertyChanged(nameof(this.price));
                }
            }
        }

        public Country? OriginCountry
        {
            get
            {
                return this.originCountry;
            }
            set
            {
                if (value != this.originCountry)
                {
                    this.originCountry = value;
                    OnPropertyChanged(nameof(this.originCountry));
                }
            }
        }

        public FrameSize? BicycleFrameSize
        {
            get
            {
                return this.bicycleFrameSize;
            }
            set
            {
                if (value != this.bicycleFrameSize)
                {
                    this.bicycleFrameSize = value;
                    OnPropertyChanged(nameof(this.bicycleFrameSize));
                }
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                if (value != this.year)
                {
                    this.year = value;
                    OnPropertyChanged(nameof(this.year));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Bicycle(string brand, string model, decimal price, Country originCountry, FrameSize size, int year)
        {
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.OriginCountry = originCountry;
            this.BicycleFrameSize = size;
            this.Year = year;
            this.Image = this.helper.GetImageByModel(model);
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
