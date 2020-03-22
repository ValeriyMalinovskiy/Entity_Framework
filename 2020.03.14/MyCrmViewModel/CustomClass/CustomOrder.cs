using MyCrmModel.Sales;

namespace MyCrmViewModel.CustomClass
{
    public class CustomOrder : Order
    {
        public string StaffName { get; set; }

        public string DeliveryAddress { get; set; }

        public string Phone { get; set; }

        public CustomOrder(Order order)
        {
            this.CustomerId = order.CustomerId;
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
        }
    }
}
