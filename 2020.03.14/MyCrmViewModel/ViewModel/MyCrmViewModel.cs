using MyCrmModel;
using MyCrmModel.Sales;
using MyCrmViewModel.Command;
using MyCrmViewModel.CustomClass;
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

        private List<Staff> staffs;

        private ObservableCollection<CustomOrder> customOrders;

        private ObservableCollection<CustomOrder> ordersToShow;

        private ObservableCollection<Customer> customersToShow;

        private CustomOrder selectedOrder;

        private bool sortByActiveOrder;

        private bool sortByActiveCustomer;

        public event PropertyChangedEventHandler PropertyChanged;

        private Customer selectedCustomer;

        public ICommand AllRadioButtonCommand { get; set; }

        public ICommand ByCustomerRadioButtonCommand { get; set; }

        public ICommand ByActiveCustomersRadioButtonCommand { get; set; }

        public ICommand AllCustomersRadioButtonCommand { get; set; }

        public MyCrmViewModel()
        {
            this.AllRadioButtonCommand = new RelayCommand(AllRadioButtonCommandExecuted, CommandCanExecute);
            this.ByCustomerRadioButtonCommand = new RelayCommand(ByCustomerRadioButtonCommandExecuted, ByCustomerRadioButtonCommandCanExecute);
            this.AllCustomersRadioButtonCommand = new RelayCommand(AllCustomersRadioButtonCommandExecuted, CommandCanExecute);
            this.ByActiveCustomersRadioButtonCommand = new RelayCommand(ByActiveCustomersRadioButtonCommandExecuted, CommandCanExecute);
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

        private bool ByCustomerRadioButtonCommandCanExecute(object obj)
        {
            if (this.SelectedCustomer == null)
            {
                return false;
            }
            return true;
        }

        private void AllRadioButtonCommandExecuted(object obj)
        {
            this.sortByActiveOrder = false;
            SortOrders();
        }

        private void ByCustomerRadioButtonCommandExecuted(object obj)
        {
            this.sortByActiveOrder = true;
            SortOrders();
        }

        private void ByActiveCustomersRadioButtonCommandExecuted(object obj)
        {
            this.sortByActiveCustomer = true;
            SortCustomers();
        }

        private void AllCustomersRadioButtonCommandExecuted(object obj)
        {
            this.sortByActiveCustomer = false;
            SortCustomers();
        }

        private void SortOrders()
        {
            if (this.sortByActiveOrder && this.SelectedCustomer != null)
            {
                this.OrdersToShow = new ObservableCollection<CustomOrder>(this.CustomOrders.
                    Where(o => o.CustomerId == this.SelectedCustomer.Id));
            }
            else
            {
                this.OrdersToShow = new ObservableCollection<CustomOrder>(this.CustomOrders.
                    Where(o => o.OrderStatus != "Completed"));
            }
        }

        private void SortCustomers()
        {
            if (this.sortByActiveCustomer)
            {
                this.CustomersToShow = new ObservableCollection<Customer>();
                var inProcessOrders = this.orders.Where(o => o.OrderStatus != "Completed");
                foreach (var order in inProcessOrders)
                {
                    foreach (var customer in this.Customers)
                    {
                        if (order.CustomerId == customer.Id && !this.CustomersToShow.Contains(customer))
                        {
                            this.CustomersToShow.Add(customer);
                        }
                    }
                }
            }
            else
            {
                this.CustomersToShow = new ObservableCollection<Customer>(this.Customers);
            }
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
                    SortOrders();
                }
            }
        }

        public ObservableCollection<CustomOrder> OrdersToShow
        {
            get
            {
                return this.ordersToShow;
            }
            set
            {
                if (value != this.ordersToShow)
                {
                    this.ordersToShow = value;
                    OnPropertyChanged(nameof(this.ordersToShow));
                }
            }
        }

        public ObservableCollection<Customer> CustomersToShow
        {
            get
            {
                return this.customersToShow;
            }
            set
            {
                if (value != this.customersToShow)
                {
                    this.customersToShow = value;
                    OnPropertyChanged(nameof(this.customersToShow));
                }
            }
        }

        private string GetStaffName()
        {
            if (this.SelectedOrder != null)
            {
                var staff = this.staffs.Single(s => s.Id == this.SelectedOrder.StaffId);
                this.SelectedOrder.StaffName = $"{staff.FirstName} {staff.LastName}";
            }
            return null;
        }

        private void GetCustomerPhone()
        {
            if (this.SelectedOrder != null)
            {
                this.SelectedOrder.Phone = this.Customers.Single(c => c.Id == this.SelectedOrder.CustomerId).Phone;
            }
        }

        private void GetCustomerAddress()
        {
            if (this.SelectedOrder != null)
            {
                var customer = this.Customers.Single(c => c.Id == this.SelectedOrder.CustomerId);
                this.SelectedOrder.DeliveryAddress = $"{customer.City} {customer.Street}";
            }
        }

        public CustomOrder SelectedOrder
        {
            get
            {
                return this.selectedOrder;
            }
            set
            {
                if (value != this.selectedOrder)
                {
                    this.selectedOrder = value;
                    GetStaffName();
                    GetCustomerAddress();
                    GetCustomerPhone();
                    OnPropertyChanged(nameof(this.selectedOrder));
                }
            }
        }

        private void PrepareView()
        {
            this.dbContext = new MyCrmModel.MyCrmDbContext();
            this.staffs = new List<Staff>(this.dbContext.Staffs);
            this.orders = this.dbContext.Orders.ToArray();
            this.CustomOrders = new ObservableCollection<CustomOrder>();
            foreach (var order in this.orders)
            {
                this.CustomOrders.Add(new CustomOrder(order));
            }
            this.Customers = new ObservableCollection<Customer>(this.dbContext.Customers);
            SortOrders();
            SortCustomers();
        }
    }
}
