using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Submarine:ISwimable
    {
        public string Model { get; set; }
        public double MaxDepthSupported { get; set; }
        public double SpeedRate { get; set; }

        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            this.Model = model;
            this.MaxDepthSupported = maxDepthSupported;
            this.SpeedRate = speedRate;
        }

        public string Swim()
        {
            return $"{this.Model} is a Submarine and is swimming in {this.MaxDepthSupported} meter depth";

        }
    }
}