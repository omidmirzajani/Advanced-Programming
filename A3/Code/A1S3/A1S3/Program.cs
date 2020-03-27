using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"..\..\TwitterData\Tweets");
            string[] ffiles = Directory.GetFiles(@"..\..\TwitterData\Words");
            int i = 0;
            string neg = "";
            string pos = "";
            foreach (var ffile in ffiles)
                if (i == 0)
                {
                    neg = ffile;
                    i++;
                }
                else
                    pos = ffile;
            string[] kol = new string[files.Length];
            int shomarande = 0;
            foreach (string file in files)
            {
                //string matn = file + ':';
                FileInfo AghaOmid = new FileInfo(file);
                string matn = AghaOmid.Name.Replace(".txt", "") + ":";
                //File.WriteAllLines(@"C:\Users\Omid\Desktop\Programming\A1S3\A1S3\result.txt", files);
                //Console.Write(file+':');
                string[] khatha = Q1_GetWords(file);
                string[] negword = Q1_GetWords(neg);
                string[] posword = Q1_GetWords(pos);
                double miangin = Q5_GetAvgPopChargeOfTweets(khatha, negword, posword);
                matn = matn + miangin;                
                kol[shomarande] = matn;
                shomarande++;
            }
            File.WriteAllLines(@"..\..\result.txt", kol);
            //files = Directory.GetFiles(@"..\..\TwitterData\Words");
            //foreach (var file in files)
            //    Console.WriteLine(file);
            //foreach (string khat in Q1_GetWords(@"C:\Users\Omid\Desktop\Programming\A1S3\A1S3\result.txt"))            
        }
        public static string[] Q1_GetWords(string path)
        {
            return File.ReadAllLines(path);                       
        }
        public static bool Q2_IsInWords(string[] words, string word)
        {
            if (words.Contains(word))
                return true;
            else
                return false;
        }
        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            string[] arr = tweet.Split(new[] {' ','!','?','#'});
            return arr;
        }
        public static int Q4_GetPopChargeOfTweet(string tweet , string[] posWords , string[] negWords)        
        {
            int mosbat = 0;
            int manfi = 0;
            foreach(string xxx in posWords)            
                if (tweet.Contains(xxx))                                    
                    mosbat++;                           
            foreach (string xxx in negWords)            
                if (tweet.Contains(xxx))                
                    manfi--;                                                           
            return mosbat + manfi;
        }
        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords, string[] posWords)
        {
            double sum = 0;            
            foreach (string a in tweets)
            {
                sum += Convert.ToDouble(Q4_GetPopChargeOfTweet(a, posWords, negWords));
            }
            double avg = sum / tweets.Length;
            return avg;
        }
    }
}