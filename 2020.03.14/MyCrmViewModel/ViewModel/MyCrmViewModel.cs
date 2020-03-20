using MyCrmModel;
using MyCrmModel.Sales;
using MyCrmViewModel.Command;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private Order selectedOrder;

        public Customer selectedCustomer { get; set; }

        public ICommand ProcessOrderSortingCommand { get; set; }

        public ICommand ProcessCustomerSortingCommand { get; set; }

        public MyCrmViewModel()
        {
            ProcessCustomerSortingCommand = new RelayCommand(ProcessCustomerSortingCommandExecuted, CommandCanExecute);
            ProcessOrderSortingCommand = new RelayCommand(ProcessOrderSortingCommandExecuted, CommandCanExecute);
            dbContext = new MyCrmModel.MyCrmDbContext();
            this.CurrentSelectionOrders = new ObservableCollection<Order>(dbContext.Orders);
            this.SelectedOrder = this.currentSelectionOrders[0];
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
    }
}
