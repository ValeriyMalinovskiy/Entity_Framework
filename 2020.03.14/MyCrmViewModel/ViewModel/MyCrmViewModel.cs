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

        private ObservableCollection<CustomOrder> customOrders;

        private ObservableCollection<CustomOrder> customOrdersSortedCollection;

        private CustomOrder selectedCustomOrder;

        public event PropertyChangedEventHandler PropertyChanged;

        private Customer selectedCustomer;

        public ICommand AllRadioButtonCommand { get; set; }

        public ICommand ProcessCustomerSortingCommand { get; set; }

        public ICommand ByCustomerRadioButtonCommand { get; set; }

        public MyCrmViewModel()
        {
            this.ProcessCustomerSortingCommand = new RelayCommand(ProcessCustomerSortingCommandExecuted, CommandCanExecute);
            this.AllRadioButtonCommand = new RelayCommand(AllRadioButtonCommandExecuted, CommandCanExecute);
            this.ByCustomerRadioButtonCommand = new RelayCommand(ByCustomerRadioButtonCommandExecuted, CommandCanExecute);
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
            this.CustomOrdersSortedCollection = this.CustomOrders;
        }        
        
        private void ByCustomerRadioButtonCommandExecuted(object obj)
        {
            this.CustomOrdersSortedCollection = new ObservableCollection<CustomOrder>(this.CustomOrders.Where(o => o.CustomerId == this.SelectedCustomer.Id));
        }

        private void ProcessCustomerSortingCommandExecuted(object obj)
        {
        }

        public ObservableCollection<CustomOrder> CustomOrders
        {
            get
            {
                return this.customOrders;
            }
            set
            {
                if (value != this.customOrders)
                {
                    this.customOrders = value;
                    OnPropertyChanged(nameof(this.customOrders));
                }
            }
        }         
        
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this.customers;
            }
            set
            {
                if (value != this.customers)
                {
                    this.customers = value;
                    OnPropertyChanged(nameof(this.customers));
                }
            }
        }         
        
        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                if (value != this.selectedCustomer)
                {
                    this.selectedCustomer = value;
                    OnPropertyChanged(nameof(this.selectedCustomer));
                }
            }
        }        
        
        public ObservableCollection<CustomOrder> CustomOrdersSortedCollection
        {
            get
            {
                return this.customOrdersSortedCollection;
            }
            set
            {
                if (value != this.customOrdersSortedCollection)
                {
                    this.customOrdersSortedCollection = value;
                    OnPropertyChanged(nameof(this.customOrdersSortedCollection));
                }
            }
        }

        public CustomOrder SelectedCustomOrder
        {
            get
            {
                return this.selectedCustomOrder;
            }
            set
            {
                if (value != this.selectedCustomOrder)
                {
                    this.selectedCustomOrder = value;
                    OnPropertyChanged(nameof(this.selectedCustomOrder));
                }
            }
        }

        private void PrepareView()
        {
            this.dbContext = new MyCrmModel.MyCrmDbContext();
            this.orders = this.dbContext.Orders.ToArray();
            this.CustomOrders = new ObservableCollection<CustomOrder>();
            foreach (var order in this.orders)
            {
                this.CustomOrders.Add(new CustomOrder(order));
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
