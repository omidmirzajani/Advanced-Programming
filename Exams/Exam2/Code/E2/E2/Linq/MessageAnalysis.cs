using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            int t = 0;
            this.Messages
                        .GroupBy(g => g.ReplyMessageId)
                        .OrderByDescending(d => d.Count())
                        .ToList()
                        .ForEach(d => {
                            t = d.First().ReplyMessageId;
                        });
            return this.Messages.Where(d => d.Id == t).First();
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            var tmp = Messages.Where(d => (d.Author != "Sauleh Eetemadi") && (d.Author != "Ali Heydari"));
            var tmp2 = tmp.GroupBy(d => d.Id)
                        .OrderByDescending(d => d.Count())
                        .Take(5)
                        .Select(d => new Tuple<string, int>( d.First().Author, d.Count() ));
                        
            return tmp2.ToArray();
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            var tmp = Messages.Where(d => (d.DateTime.Hour >= 0) && (d.DateTime.Hour <= 4))
                              .GroupBy(d => d.Id)
                              .OrderByDescending(d => d.Count())
                              .Take(5)
                              .Select(d => new Tuple<string, int>(d.First().Author, d.Count()));

            return tmp.ToArray();
                              
        }
        
        public string StudentWithMostUnansweredQuestions()
        {
            string s = "";
            Messages.GroupBy(d => d.Content.Contains("?") || d.Content.Contains("؟"))
                              .OrderByDescending(d => d.Count())
                              .First()
                              .ToList()
                              .ForEach(d => s = d.Author);
            return s;
        }
    }
}