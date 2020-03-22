using MyCrmModel.Production;

namespace MyCrmViewModel.CustomClass
{
    public class CustomProduct : Product
    {
        public string Brand { get; set; }

        public string Category { get; set; }

        public int Stock { get; set; }

        public CustomProduct(Product product)
        {
            this.Id = product.Id;
            this.BrandId = product.BrandId;
            this.CategoryId = product.CategoryId;
            this.ListPrice = product.ListPrice;
            this.ModelYear = product.ModelYear;
            this.Name = product.Name;
            this.OrderItems = product.OrderItems;
            this.Stocks = product.Stocks;
            GetStock();
        }

        private void GetStock()
        {
            foreach (var item in this.Stocks)
            {
                this.Stock += item.Quantity;
            }
        }

        public override string ToString()
        {
            return $"Product {this.Id:0000}";
        }
    }
}
