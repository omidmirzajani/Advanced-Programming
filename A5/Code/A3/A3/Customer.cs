using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        private string _Name;
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }
        private City _City;
        public City City
        {
            get { return this._City; }
            set { this._City = value; }
        }
        private List<Order> _Orders;
        public List<Order> Orders
        {
            get { return this._Orders; }
            set { this._Orders = value; }
        }      
        public Customer(string name,City city, List<Order> orders)
        {
            this.Name = name;
            this.City = city;
            this.Orders = orders;
        }
        public Product MostOrderedProduct()
        {            
            Product[] NameOfProducts = new Product[100000];
            int[] Tekrar = new int[100000];
            int h = 0;
            foreach (Order item in Orders)
                foreach (Product i in item.Products)
                {
                    if (NameOfProducts.Contains(i))
                    {
                        int index = 0;
                        for(int k=0;k<NameOfProducts.Length;k++)
                        {
                            if(NameOfProducts[k]==i)
                            {
                                index = k;
                                break;
                            }
                        }
                        Tekrar[index]++; 
                    }
                    else
                    {
                        NameOfProducts[h] = i;
                        Tekrar[h] = 0;
                    }
                    h++;
                }
            int maximom = 0;
            Product max_order = null;
            for(int m=0;m<Tekrar.Length;m++)
            {
                if(maximom<Tekrar[m])
                {
                    maximom = Tekrar[m];
                    max_order = NameOfProducts[m];
                }
            }            
            return max_order;
        }
        public List<Order> UndeliveredOrders()
        {
            List<Order> undelivered = new List<Order>();            
            foreach (Order ords in this.Orders)
            {
                if(ords.IsDelivered==false)
                {
                    undelivered.Add(ords);
                }
            }
            return undelivered;
        }
        
    }
}