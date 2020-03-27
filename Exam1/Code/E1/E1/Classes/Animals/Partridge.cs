using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge:IWalkable,IFlyable,IAnimal
    {


        public double SpeedRate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public Partridge(string name, int age, double speedRate, double health)
        {
            this.Name = name;
            this.Age = age;
            this.SpeedRate = speedRate;
            this.Health = health;
        }

        public string EatFood()
        {
            return $"{this.Name} is a Partridge and is eating";
        }

        public string Fly()
        {
            return $"{this.Name} is a Partridge and is flying";
        }

        public string Move(Environment env)
        {
            if (env == Environment.Watery)
                return $"{this.Name} is a Partridge and can't move in Watery environment";
            else if (env == Environment.Land)
                return this.Walk();
            return this.Fly();

        }

        public string Reproduction(IAnimal animal)
        {
            return $"{this.Name} is a Partridge and reproductive with {animal.Name}";
        }

        public string Walk()
        {
            return $"{this.Name} is a Partridge and is walking";
        }
    }
}