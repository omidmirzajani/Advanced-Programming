namespace A7
{
    public class Dabir : ICitizen, ITeacher
    {             
        public string Name { get; set; }
        public string NationalId { get; set; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public int Under100StudentCount { get; set; }
        
        public Dabir(string nationaial, string name, string img, Degree top,int under1000)
        {
            this.Name = name;
            this.NationalId = nationaial;
            this.TopDegree = top;
            this.ImgUrl = img;
            this.Under100StudentCount = under1000;
        }
        public string Teach()
        {
            return $"Dabir { this.Name} is teaching";
        }
    }
}