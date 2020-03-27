using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    public class Human
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public int Height { get; set; }
        public Human(string f,string l,DateTime b,int h)
        {
            this.Firstname = f;
            this.Lastname = l;
            this.Birthdate = b;
            this.Height = h;
        }        
        public static Human operator +(Human h1,Human h2)
        {
            return new Human("ChildFirstName", 
                "ChildLastName",
                DateTime.Now,
                30);
        }
        public static bool operator >=(Human h1, Human h2)
        {
            return (h1.Height >= h2.Height);
        }
        public static bool operator <=(Human h1, Human h2)
        {
            return (h1.Height <= h2.Height);
        }
        public static bool operator >(Human h1, Human h2)
        {
            return (h1.Height > h2.Height);
        }
        public static bool operator <(Human h1, Human h2)
        {
            return (h1.Height < h2.Height);
        }
        public static bool operator ==(Human h1, Human h2)
        {
            return (h1.Height == h2.Height);
        }
        public static bool operator !=(Human h1, Human h2)
        {
            return (h1.Height != h2.Height);
        }

        public override bool Equals(object obj)
        {
            Human h = obj as Human;
            return (h.Firstname == this.Firstname) && (h.Lastname == this.Lastname) && (h.Birthdate == this.Birthdate) && (h.Height == this.Height);
        }
        public override int GetHashCode()
        {
            int s =  this.Firstname.GetHashCode();
            s = s * this.Lastname.GetHashCode();
            s = s * this.Birthdate.GetHashCode();
            s = s * this.Height.GetHashCode();
            return s;
        }
    }    
    public class Program
    {
        public static bool SumOperator(Human h1,Human h2)
        {
            Human h= new Human("ChildFirstName",
                "ChildLastName",
                new DateTime(),
                30);
            return (h == h1 + h2);
        }
        public static bool BozorgMosavi(Human h1, Human h2)
        {
            return h1 >= h2;
        }
        public static bool KoochikMosavi(Human h1, Human h2)
        {
            return h1 <= h2;
        }
        public static bool Bozorg(Human h1, Human h2)
        {
            return h1 > h2;
        }
        public static bool Koochik(Human h1, Human h2)
        {
            return h1 < h2;
        }
        public static bool Mosavi(Human h1, Human h2)
        {
            return h1 == h2;
        }
        public static bool NaMosavi(Human h1, Human h2)
        {
            return h1 != h2;
        }
        public static bool equal(Human h1, Human h2)
        {
            return h1.Equals(h2);
        }

        public static int Hash(Human h1)
        {
            return h1.GetHashCode();
        }


        public static void Main(string[] args)
        {
            
        }
    }
}
