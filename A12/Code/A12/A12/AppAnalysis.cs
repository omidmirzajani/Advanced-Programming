using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A12
{
    public class AppAnalysis
    {
        public List<AppData> Apps=new List<AppData>();
        public AppAnalysis()
        { }

        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                int i = 0;
                while (!parser.EndOfData)
                {
                    i++;
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;
        }

        public void AppendApp(string[] fields)
        {
            AppData ap = new AppData(fields);
            this.Apps.Add(ap);
        }

        public int AllAppsCount()
        {
            return this.Apps
                       .ToArray()
                       .Length;
        }

        public object AppsAboveXRatingCount(double v)
        {
            return this.Apps
                       .Where(l => (l.Rating >= v))
                       .ToList()
                       .Count;                              
        }

        public string RecentlyUpdatedCount(DateTime dateTime)
        {
            return this.Apps
                       .Where(l => l.LastUpdate >= dateTime)
                       .ToArray()
                       .Length
                       .ToString();
        }

        public string RecentlyUpdatedFreqCat(DateTime dateTime)
        {
            return this.Apps
                        .Where(l => l.LastUpdate >= dateTime)
                        .GroupBy(d => d.Category)
                        .OrderByDescending(g => g.Count())
                        .Select(l => l.First().Category)
                        .First();
                        
        }
        
        public List<string> MostRatedCategories(double v1, int v2)
        {            
            return this.Apps
                .Where(l => l.Rating > v1)
                .GroupBy(d => d.Category)
                .OrderByDescending(g => g.Count())
                .Select(l => l.First().Category)
                .Take(v2)
                .ToList();            
        }

        public Tuple<string,string> ExtremeMeanUpdateElapse(DateTime dateTime)
        {
            var item1 = this.Apps
                       .GroupBy(d => d.Category)
                       .OrderByDescending(g => g.Average(line => DateTime.Now.Ticks - line.LastUpdate.Ticks))
                       .Select(g => g.Key).Last();
            var item2 = this.Apps
                       .GroupBy(d => d.Category)
                       .OrderByDescending(g => g.Average(line => DateTime.Now.Ticks - line.LastUpdate.Ticks))
                       .Select(g => g.Key).First();
            return new Tuple<string, string>(item1, item2);
            


        }        

        public double TopQuarterBoundary()
        {
            var item = this.Apps
                           .Where(d => d.Category == "PHOTOGRAPHY")
                           .OrderByDescending(d => d.Rating)
                           .Select(d=>d.Rating)
                           .ToArray();
            return item[(Convert.ToInt32(item.Length/4))];
        }

        public List<string> XMostProfitables(int x)
        {
            var tmp = this.Apps
                        .Where(d => d.IsFree == 0)
                        .OrderByDescending(d => d.Price * d.Installs)
                        .Select(a => a.Name)
                        .Take(x)
                        .ToList();
            return tmp;

        }

        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
        {
            var tmp = this.Apps                          
                          .OrderBy(d => criteria(d))
                          .Select(a => a.Name)
                          .Take(x)
                          .ToList();
            return tmp;

        }
    }
}
