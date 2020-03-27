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
            List<int?> list = new List<int?>();
            this.Messages
                .Where(d=>d.ReplyMessageId!=null)
                .GroupBy(d => d.ReplyMessageId)
                .OrderByDescending(g => g.Count())
                .First()
                .ToList()
                .ForEach(g => list.Add(g.ReplyMessageId));
            return this.Messages.Where(d => (d.Id == list.First())).First();
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            var tmp = Messages.Where(d => (d.Author != "Sauleh Eetemadi") && (d.Author != "Ali Heydari"));
            var tmp2 = tmp.GroupBy(d => d.Author)
                        .OrderByDescending(d => d.Count())
                        .Take(5)
                        .Select(d => new Tuple<string, int>( d.First().Author, d.Count() ));
                        
            return tmp2.ToArray();
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {            
            var tmp = Messages.Where(d => (d.DateTime.Hour >= 0) && (d.DateTime.Hour <= 4))
                              .GroupBy(d => d.Author)
                              .Select(l =>{
                                  return new
                                  {
                                      tedad = l.Count(),
                                      name = l.First().Author
                                  };
                              }
                              )
                              .OrderByDescending(d => d.tedad)
                              .Take(5)
                              .Select(d => new Tuple<string, int>(d.name, d.tedad))
                              .ToArray();

            return tmp;
                              
        }
        
        public string StudentWithMostUnansweredQuestions()
        {
            List<int?> replyId = new List<int?>();
            Messages.ToList().ForEach(d => replyId.Add(d.ReplyMessageId));
            var pmQuesOrderd = "";
            Messages.Where(d => d.Content.Contains("?") || d.Content.Contains("؟"))
                              .Where(d=>d.Author!="Ali Heydari")
                              .Where(d => !replyId.Contains(d.Id))
                              .GroupBy(d => d.Author)
                              .OrderByDescending(d => d.Count())
                              .First()
                              .ToList()
                              .ForEach(d => pmQuesOrderd = d.Author);
            return pmQuesOrderd;
        }
    }
}