using MyCrmModel;
using MyCrmModel.Sales;
using MyCrmViewModel.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MyCrmViewModel
{
    public class MyCrmViewModel : INotifyPropertyChanged
    {
        public MyCrmDbContext dbContext { get; set; }

        private IEnumerable<Order> orders;

        private ObservableCollection<Customer> customers;

        private ObservableCollection<CustomOrder> customizedOrders;

        private ObservableCollection<CustomOrder> customizedOrdersSortedCollection;

        private CustomOrder selectedCustomizedOrder;

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer selectedCustomer { get; set; }

        public ICommand AllRadioButtonCommand { get; set; }

        public ICommand ProcessCustomerSortingCommand { get; set; }

        public MyCrmViewModel()
        {
            this.ProcessCustomerSortingCommand = new RelayCommand(ProcessCustomerSortingCommandExecuted, CommandCanExecute);
            this.AllRadioButtonCommand = new RelayCommand(AllRadioButtonCommandExecuted, CommandCanExecute);
            PrepareView();
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool CommandCanExecute(object obj)
        {
            return true;
        }

        private void AllRadioButtonCommandExecuted(object obj)
        {
            this.CustomizedOrdersSortedCollection = this.CustomizedOrders;
        }        
        
        private void ByCustomerRadioButtonCommandExecuted(object obj)
        {
            foreach (var item in this.CustomizedOrders)
            {
                if (item.CustomerId == )
                {
                    this.CustomizedOrdersSortedCollection.Add(item);
                }
            }
        }

        private void ProcessCustomerSortingCommandExecuted(object obj)
        {
        }

        public ObservableCollection<CustomOrder> CustomizedOrders
        {
            get
            {
                return this.customizedOrders;
            }
            set
            {
                if (value != this.customizedOrders)
                {
                    this.customizedOrders = value;
                    OnPropertyChanged(nameof(this.customizedOrders));
                }
            }
        }        
        
        public ObservableCollection<CustomOrder> CustomizedOrdersSortedCollection
        {
            get
            {
                return this.customizedOrdersSortedCollection;
            }
            set
            {
                if (value != this.customizedOrdersSortedCollection)
                {
                    this.customizedOrdersSortedCollection = value;
                    OnPropertyChanged(nameof(this.customizedOrdersSortedCollection));
                }
            }
        }

        public CustomOrder SelectedCustomizedOrder
        {
            get
            {
                return this.selectedCustomizedOrder;
            }
            set
            {
                if (value != this.selectedCustomizedOrder)
                {
                    this.selectedCustomizedOrder = value;
                    OnPropertyChanged(nameof(this.selectedCustomizedOrder));
                }
            }
        }

        private void PrepareView()
        {
            this.dbContext = new MyCrmModel.MyCrmDbContext();
            this.orders = this.dbContext.Orders.ToArray();
            this.CustomizedOrders = new ObservableCollection<CustomOrder>();
            foreach (var order in this.orders)
            {
                this.CustomizedOrders.Add(new CustomOrder(order));
            }
            this.Customers =  new ObservableCollection<Customer>(this.dbContext.Customers);
        }
    }

    public class CustomOrder : Order
    {
        public CustomOrder(Order order)
        {
            this.CustomerId = order.Id;
            this.Id = order.Id;
            this.OrderDate = order.OrderDate;
            this.OrderItems = order.OrderItems;
            this.OrderStatus = order.OrderStatus;
            this.RequiredDate = order.RequiredDate;
            this.ShippedDate = order.ShippedDate;
            this.StaffId = order.StaffId;
            this.Store = order.Store;
            this.StoreId = order.StoreId;
        }

        private decimal GetOrderSum()
        {
            decimal sum = 0;
            foreach (var item in this.OrderItems)
            {
                sum += item.ListPrice * item.Quantity - item.Discount;
            }
            return sum;
        }

        public override string ToString()
        {
            return $"Order {this.Id:0000}\t{this.OrderDate:d}\t{GetOrderSum():n2}";
            ;
        }
    }
}
