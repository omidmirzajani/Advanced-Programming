namespace A3
{
    public class Product
    {
        string _Name;
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }
        double _Price;
        public double Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }

        public Product(string name,double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}