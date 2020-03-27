using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where _Type : IAnimal
    {
        public List<IAnimal> Animals { get; set; }
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }
        public string[] MoveAnimals()
        {
            string[] res = new string[3 * Animals.Count()];
            int i = 0;
            foreach (IAnimal ani in Animals)
            {
                res[i] = ani.Move(Environment.Air);
                i++;
                res[i] = ani.Move(Environment.Land);
                i++;
                res[i] = ani.Move(Environment.Watery);
                i++;
            }
            return res;
        }
    }
}