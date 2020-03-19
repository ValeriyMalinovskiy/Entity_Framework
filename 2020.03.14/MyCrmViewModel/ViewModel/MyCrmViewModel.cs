using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;
using MyCrmModel;
using MyCrmModel.Sales;
using MyCrmViewModel.Command;

namespace MyCrmViewModel
{
    public class MyCrmViewModel
    {
        public MyCrmDbContext dbContext { get; set; }

        public ObservableCollection<Order> currentSelectionOrders { get; set; }

        public ObservableCollection<Customer> currentSelectionCustomers { get; set; }

        public Order selectedOrder { get; set; }

        public Customer selectedCustomer { get; set; }

        public ICommand ProcessOrderSortingCommand { get; set; }

        public ICommand ProcessCustomerSortingCommand { get; set; }

        public MyCrmViewModel()
        {
            this.ProcessCustomerSortingCommand = new RelayCommand(ProcessCustomerSortingCommandExecuted, CommandCanExecute);
            this.ProcessOrderSortingCommand = new RelayCommand(ProcessOrderSortingCommandExecuted, CommandCanExecute);
            this.dbContext = new MyCrmModel.MyCrmDbContext();
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
    }
}
