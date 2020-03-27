namespace E2
{
    public abstract class Person
    {
        protected Person(string name, bool isFemale)
        {
            Name = name;
            IsFemale = isFemale;
        }

        public bool IsFemale { get; set; }
        public abstract int LunchRate { get; }
        private string _Name;
        public virtual string Name
        {
            get
            {
                if(IsFemale==true)
                    return "خانم "+this._Name;
                else
                    return "آقای " + this._Name;
            }

            set
            {
                this._Name = value;
            }
        }
        
    }

    public class Student : Person
    {
        public Student(string name, bool isFemale) : base(name, isFemale)
        {
        }

        public override int LunchRate => 2000;
    }
    
    public class Employee : Person
    {
        public Employee(string name, bool isFemale) : base(name, isFemale)
        {
        }

        public override int LunchRate => 5000;
        public virtual int CalculateSalary(int t)
        {
            return 5000*t;
        }
    }

    public class Teacher : Employee
    {
        public Teacher(string name, bool isFemale) : base(name, isFemale)
        {
        }

        public override int LunchRate => 10000;

        public override string Name => "استاد " + base.Name.Substring(5);

        public override int CalculateSalary(int t)
        {
            return base.CalculateSalary(t)*4;
        }
    }

}