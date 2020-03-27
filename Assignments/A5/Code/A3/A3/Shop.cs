using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
    {
        private string _Name;
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }
        private List<Customer> _Customers;
        public List<Customer> Customers
        {
            get { return this._Customers; }
            set { this._Customers = value; }
        }
        
        public Shop(string name, List<Customer> customers)
        {
            this.Name = name;
            this.Customers = customers;
        }


        public List<City> CitiesCustomersAreFrom()
        {
            List<City> c = new List<City>();
            foreach (Customer i in Customers)
            {
                if (c.Contains(i.City) == false)
                    c.Add(i.City);
            }
            return c;

        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> c = new List<Customer>();
            foreach (Customer item in Customers)
            {
                if (item.City == city)
                    c.Add(item);
            }
            return c;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            int[] tul = new int[1000];
            int i = 0;
            int max = 0;
            List<Customer> c = new List<Customer>();
            foreach (Customer item in Customers)
            {
                tul[i] = item.Orders.Count();
                if (tul[i] > max)
                    max = tul[i];
                i++;
            }
            foreach (Customer item in Customers)
            {
                if (item.Orders.Count() == max)
                    c.Add(item);
            }
            return c;
        }
    }
}