using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Q1_GetWordsTest()
        {
            string path = Path.GetTempFileName();
            string[] arr = { "sda", "asda" };
            File.WriteAllLines(path, arr);
            CollectionAssert.AreEqual(arr, Program.Q1_GetWords(path));
            
        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {
            string[] words = { "abc", "omid" };
            string word = "abc";
            bool res = true;
            Assert.AreEqual(res, Program.Q2_IsInWords(words, word));
        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string sentence = "omid jan";
            string[] res = { "omid", "jan" };
            CollectionAssert.AreEqual(res, Program.Q3_GetWordsOfTweet(sentence));
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string sentence = "omid jan in gol divane";
            string[] neg = { "divane" };
            string[] pos = { "jan", "gol" };
            int res = 1;
            Assert.AreEqual(res, Program.Q4_GetPopChargeOfTweet(sentence, pos, neg));
        }

        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            string[] sentence = { "omid jan in gol divane", "ali jan is divane" };
            string[] neg = { "divane" };
            string[] pos = { "jan", "gol" };
            double res = 0.5;
            Assert.AreEqual(res, Program.Q5_GetAvgPopChargeOfTweets(sentence, neg, pos));
        }
    }
}