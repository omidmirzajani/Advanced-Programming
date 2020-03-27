using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow:IFlyable,IAnimal
    {
        

        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }
        public Crow(string name, int age, double health, double speedRate)
        {
            this.Name = name;
            this.Age = age;
            this.Health = health;
            this.SpeedRate = speedRate;
        }
        public string EatFood()
        {
            return $"{this.Name} is a Crow and is eating";
        }

        public string Fly()
        {
            return $"{this.Name} is a Crow and is flying";
        }

        public string Move(Environment env)
        {
            if (env == Environment.Watery)
                return $"{this.Name} is a Crow and can't move in Watery environment";
            else if (env == Environment.Land)
                return $"{this.Name} is a Crow and can't move in Land environment";
            return this.Fly();
        }

        public string Reproduction(IAnimal animal)
        {
            return $"{this.Name} is a Crow and reproductive with {animal.Name}";
        }
    }
}