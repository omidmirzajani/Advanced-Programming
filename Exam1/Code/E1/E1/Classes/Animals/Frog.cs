using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog:IWalkable,ISwimable,IAnimal
    {
        public double SpeedRate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }

        public Frog(string name, int age, double health, double speedRate)
        {
            this.Name = name;
            this.SpeedRate = speedRate;
            this.Age = age;
            this.Health = health;
        }
        public string EatFood()
        {
            return $"{this.Name} is a Frog and is eating";
        }

        public string Move(Environment env)
        {
            if (env == Environment.Air)
                return $"{this.Name} is a Frog and can't move in Air environment";
            else if (env == Environment.Land)
                return this.Walk();
            return this.Swim();

        }

        public string Reproduction(IAnimal animal)
        {
            return $"{this.Name} is a Frog and reproductive with {animal.Name}";
        }

        public string Swim()
        {
            return $"{this.Name} is a Frog and is swimming";
        }

        public string Walk()
        {
            return $"{this.Name} is a Frog and is walking";
        }
    }
}