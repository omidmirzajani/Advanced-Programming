using System;
using System.Collections.Generic;
using System.Globalization;

namespace A12
{
    public class AppData
    {
        public string Name;
        public string Category;
        public double Rating;
        public long Reviews;
        public double Size;
        public long Installs;
        public long IsFree;
        public double Price;
        public string ContentRating;
        public List<string> Genres;
        public DateTime LastUpdate;
        public string CurrentVersion;
        public string AndroidVersion;
        public AppData(string[] fields)
        {
            this.Name = fields[0];
            this.Category = fields[1];           
            if (!double.TryParse(fields[2], out Rating))
                Rating = 0;
            try
            {
                this.Reviews = long.Parse(fields[3]);
            }
            catch
            {
                this.Reviews = 0;
            }
            
            try
            {
                int len = fields[4].Length;
                this.Size = double.Parse(fields[4].Substring(0, len - 1));
            }
            catch
            {
                this.Size = 0;
            }

            try
            {
                int lenI = fields[5].Length;
                this.Installs = long.Parse(fields[5].Substring(0, lenI - 1), NumberStyles.AllowThousands);
            }
            catch
            {
                this.Installs = 0;
            }
            if (fields[6] == "Free")
                this.IsFree = 1;
            else
                this.IsFree = 0;
            try
            {
                this.Price = double.Parse(fields[7].Replace("$",""));                
            }
            catch
            {
                this.Price = 0;
            }
            this.ContentRating = fields[8];
            this.Genres = new List<string>() { fields[9] };            
            try
            {
                this.LastUpdate = DateTime.Parse(fields[10]);
            }
            catch
            {
                this.LastUpdate = DateTime.Now;
            }
            this.CurrentVersion = fields[11];
            this.AndroidVersion = fields[12];
        }
    }
}
