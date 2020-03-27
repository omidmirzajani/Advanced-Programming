using System;
using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        public string Title { get; set; }        
        public Degree MinimumDegree { get; set; }
        public List<TTeacher> Teachers{ get; set; }
        public EduInstitute(string title,Degree min)
        {
            this.Title = title;
            this.MinimumDegree = min;
            
        }
        public bool Register(TTeacher teacher)
        {
            if (IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }
            return false;

        }

        public bool IsEligible(TTeacher teacher)
        {
            return (this.MinimumDegree <= teacher.TopDegree);
        }
    }
}