namespace A7
{
    public class Professor:ITeacher,ICitizen
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public int ResearchCount { get; set; }

        public Professor(string nationaial, string name, string img, Degree top, int res)
        {
            this.Name = name;
            this.NationalId = nationaial;
            this.TopDegree = top;
            this.ImgUrl = img;
            this.ResearchCount = res;
        }
        public string Teach()
        {
            return $"Professor { this.Name} is teaching";
        }

    }
}