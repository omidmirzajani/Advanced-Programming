namespace A7
{
    public class Khalle : ICitizen, ITeacher
    {        
        public string Name { get ; set ; }
        public string NationalId { get ; set ; }
        public Degree TopDegree { get ; set; }
        public string ImgUrl { get; set; }
        
        public Khalle(string nationaial, string name,string img,Degree top)
        {
            this.Name = name;
            this.NationalId = nationaial;
            this.TopDegree = top;
            this.ImgUrl = img;
        }
        public string Teach()
        {
            return $"Khalle { this.Name} is teaching";
        }
    }
}