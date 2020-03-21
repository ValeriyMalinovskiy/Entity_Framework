using MyCrmModel;
using MyCrmModel.Sales;
using MyCrmViewModel.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MyCrmViewModel
{
    public class MyCrmViewModel : INotifyPropertyChanged
    {
        public MyCrmDbContext dbContext { get; set; }

        public ObservableCollection<Order> currentSelectionOrders { get; set; }

        private ObservableCollection<Customer> currentSelectionCustomers;

        private ObservableCollection<string> customizedOrderInfo;

        public event PropertyChangedEventHandler PropertyChanged;

        private Order selectedOrder;

        public Customer selectedCustomer { get; set; }

        public ICommand ProcessOrderSortingCommand { get; set; }

        public ICommand ProcessCustomerSortingCommand { get; set; }

        public MyCrmViewModel()
        {
            this.ProcessCustomerSortingCommand = new RelayCommand(ProcessCustomerSortingCommandExecuted, CommandCanExecute);
            this.ProcessOrderSortingCommand = new RelayCommand(ProcessOrderSortingCommandExecuted, CommandCanExecute);
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

        private void ProcessOrderSortingCommandExecuted(object obj)
        {
        }

        private void ProcessCustomerSortingCommandExecuted(object obj)
        {
        }

        public ObservableCollection<Order> CurrentSelectionOrders
        {
            get
            {
                return this.currentSelectionOrders;
            }
            set
            {
                if (value != this.currentSelectionOrders)
                {
                    this.currentSelectionOrders = value;
                    OnPropertyChanged(nameof(this.currentSelectionOrders));
                }
            }
        }

        public ObservableCollection<string> CustomizedOrderInfo
        {
            get
            {
                return this.customizedOrderInfo;
            }
            set
            {
                if (value != this.customizedOrderInfo)
                {
                    this.customizedOrderInfo = value;
                    OnPropertyChanged(nameof(this.customizedOrderInfo));
                }
            }
        }

        public Order SelectedOrder
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
                    OnPropertyChanged(nameof(this.selectedOrder));
                }
            }
        }

        private void PrepareView()
        {
            this.dbContext = new MyCrmModel.MyCrmDbContext();
            this.CurrentSelectionOrders = new ObservableCollection<Order>(this.dbContext.Orders);
            this.SelectedOrder = this.currentSelectionOrders[0];
            this.CustomizedOrderInfo = GetCustomOrderInfo(this.CurrentSelectionOrders);
        }

        private ObservableCollection<string> GetCustomOrderInfo(IEnumerable<Order> orders)
        {
            ObservableCollection<string> customOrderInfo = new ObservableCollection<string>();
            foreach (var order in orders)
            {
                customOrderInfo.Add(order.Id + "\t" + order.OrderDate + "\t" + GetOrderSum(order));
            }
            return customOrderInfo;
        }

        private decimal GetOrderSum(Order order)
        {
            decimal sum = 0;
            foreach (var item in order.OrderItems)
            {
                sum += item.ListPrice * item.Quantity - item.Discount;
            }
            return sum;
        }
    }
}
