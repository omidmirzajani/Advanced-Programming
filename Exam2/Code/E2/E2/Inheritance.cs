namespace E2
{
    public abstract class Person
    {
        public string Name
        {
            get
            {
                if(IsFemale==true)
                    return "خانم"+this.Name;
                else
                    return "آقای" + this.Name;
            }

            set
            {
                this.Name = value;
            }
        }
        public bool IsFemale { get; set; }
    }

    public class Student : Person
    {
    }

    public class Employee : Person
    {
    }

    public class Teacher: Employee
    {
    }
}