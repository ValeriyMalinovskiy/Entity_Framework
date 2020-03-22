using MyCrmModel;
using MyCrmModel.Production;
using MyCrmModel.Sales;
using MyCrmViewModel.Command;
using MyCrmViewModel.CustomClass;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MyCrmViewModel
{
    public class MyCrmViewModel : INotifyPropertyChanged
    {
        private MyCrmDbContext dbContext;

        private Order[] orders;

        private Product[] products;

        private Brand[] brands;

        private Category[] categories;

        private Customer[] customers;

        private Staff[] staffs;

        private ObservableCollection<CustomOrder> customOrders;

        private ObservableCollection<CustomProduct> customProducts;

        private ObservableCollection<CustomOrder> ordersToShow;

        private ObservableCollection<Customer> customersToShow;

        private CustomOrder selectedOrder;

        private CustomProduct selectedProduct;

        private Customer selectedCustomer;

        private bool sortByActiveOrder = true;

        private bool sortByActiveCustomer = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ShowActiveOrdersCommand { get; set; }

        public ICommand ShowOrdersByCustomerCommand { get; set; }

        public ICommand ShowCustomersWithActiveOrdersCommand { get; set; }

        public ICommand ShowAllCustomersCommand { get; set; }

        public MyCrmViewModel()
        {
            this.ShowActiveOrdersCommand = new RelayCommand(ShowActiveOrdersCommandExecuted, CommandCanExecute);
            this.ShowOrdersByCustomerCommand = new RelayCommand(ShowOrdersByCustomerCommandExecuted, ByCustomerRadioButtonCommandCanExecute);
            this.ShowAllCustomersCommand = new RelayCommand(ShowAllCustomersCommandExecuted, CommandCanExecute);
            this.ShowCustomersWithActiveOrdersCommand = new RelayCommand(ShowCustomersWithActiveOrdersCommandExecuted, CommandCanExecute);
            LoadData();
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

        private void ShowOrdersByCustomerCommandExecuted(object obj)
        {
            this.sortByActiveOrder = false;
            SortOrders();
        }

        private void ShowCustomersWithActiveOrdersCommandExecuted(object obj)
        {
            this.sortByActiveCustomer = true;
            SortCustomers();
            SortOrders();
        }

        private void ShowActiveOrdersCommandExecuted(object obj)
        {
            this.sortByActiveOrder = true;
            SortOrders();
        }

        private void ShowAllCustomersCommandExecuted(object obj)
        {
            this.sortByActiveCustomer = false;
            SortCustomers();
            SortOrders();
        }

        private void SortOrders()
        {
            if (this.sortByActiveOrder && !this.sortByActiveCustomer)
            {
                this.OrdersToShow = new ObservableCollection<CustomOrder>(this.CustomOrders.
                    Where(o => o.OrderStatus != "Completed"));
            }
            else if (this.sortByActiveOrder && this.sortByActiveCustomer)
            {
                this.OrdersToShow = new ObservableCollection<CustomOrder>(this.CustomOrders.
                    Where(o => o.OrderStatus != "Completed"));
            }
            else if (!this.sortByActiveOrder && !this.sortByActiveCustomer)
            {
                if (this.SelectedCustomer != null)
                {
                    this.OrdersToShow = new ObservableCollection<CustomOrder>(this.CustomOrders.
                        Where(o => o.CustomerId == this.SelectedCustomer.Id));
                }
                else
                {
                    this.OrdersToShow = null;
                }
            }
            else if (!this.sortByActiveOrder && this.sortByActiveCustomer)
            {
                if (this.SelectedCustomer != null)
                {
                    this.OrdersToShow = new ObservableCollection<CustomOrder>(this.CustomOrders.
                        Where(o => o.CustomerId == this.SelectedCustomer.Id));
                }
                else
                {
                    this.OrdersToShow = null;
                }
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
                    foreach (var customer in this.customers)
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
                this.CustomersToShow = new ObservableCollection<Customer>(this.customers);
            }
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

        public ObservableCollection<CustomProduct> CustomProducts
        {
            get
            {
                return this.customProducts;
            }
            set
            {
                if (value != this.customProducts)
                {
                    this.customProducts = value;
                    OnPropertyChanged(nameof(this.customProducts));
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
                    SortOrders();
                    OnPropertyChanged(nameof(this.selectedCustomer));
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

        private void GetStaffName()
        {
            if (this.SelectedOrder != null)
            {
                var staff = this.staffs.Single(s => s.Id == this.SelectedOrder.StaffId);
                this.SelectedOrder.StaffName = $"{staff.FirstName} {staff.LastName}";
            }
        }

        private void GetProductBrandName()
        {
            if (this.SelectedProduct != null)
            {
                var brand = this.brands.Single(b => b.Id == this.SelectedProduct.BrandId);
                this.SelectedProduct.Brand = brand.Name; ;
            }
        }

        private void GetProductCategory()
        {
            if (this.SelectedProduct != null)
            {
                var category = this.categories.Single(c => c.Id == this.SelectedProduct.CategoryId);
                this.SelectedProduct.Category = category.Name; ;
            }
        }

        private void GetCustomerPhone()
        {
            if (this.SelectedOrder != null)
            {
                this.SelectedOrder.Phone = this.customers.Single(c => c.Id == this.SelectedOrder.CustomerId).Phone;
            }
        }

        private void GetCustomerAddress()
        {
            if (this.SelectedOrder != null)
            {
                var customer = this.customers.Single(c => c.Id == this.SelectedOrder.CustomerId);
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

        public CustomProduct SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                if (value != this.selectedProduct)
                {
                    this.selectedProduct = value;
                    GetProductBrandName();
                    GetProductCategory();
                    OnPropertyChanged(nameof(this.selectedProduct));
                }
            }
        }

        private void PrepareView()
        {
            SortOrders();
            SortCustomers();
        }

        private void LoadData()
        {
            this.dbContext = new MyCrmModel.MyCrmDbContext();
            this.staffs = this.dbContext.Staffs.ToArray();
            this.orders = this.dbContext.Orders.ToArray();
            this.CustomOrders = new ObservableCollection<CustomOrder>();
            this.CustomProducts = new ObservableCollection<CustomProduct>();
            foreach (var order in this.orders)
            {
                this.CustomOrders.Add(new CustomOrder(order));
            }
            this.products = this.dbContext.Products.ToArray();
            foreach (var product in this.products)
            {
                this.CustomProducts.Add(new CustomProduct(product));
            }
            this.customers = this.dbContext.Customers.ToArray();
            this.brands = this.dbContext.Brands.ToArray();
            this.categories = this.dbContext.Categories.ToArray();
        }
    }
}
