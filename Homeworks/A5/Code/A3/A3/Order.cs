using System.Collections.Generic;
namespace A3
{
    public class Order
    {
        private List<Product> _Products;
        public List<Product> Products
        {
            get { return this._Products; }
            set { this._Products = value; }
        }
        private bool _IsDelivered;
        public bool IsDelivered
        {
            get { return this._IsDelivered; }
            set { this._IsDelivered = value; }
        }

        public Order(List<Product> products, bool isDelivered)
        {
            this.Products = products;
            this.IsDelivered = isDelivered;
        }
        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (Product item in Products)
                totalPrice += item.Price;
            return totalPrice;
        }
        

    }
}