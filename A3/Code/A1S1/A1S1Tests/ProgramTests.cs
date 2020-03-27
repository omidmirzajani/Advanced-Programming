using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void FileSizeTest()
        {
            int linecount;
            int charcount;
            string filepath = GetTestFile(out linecount, out charcount);
            Assert.AreEqual(charcount, Program.FileSize(filepath));
        }
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i=0; i<lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }

[TestMethod()]
        public void ListFilesTest()
        {
            string filepath = "";
            string[] arr = GetTestDir(out filepath);
            CollectionAssert.Equals(arr, Program.ListFiles(filepath));
        }
        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
                File.Delete(tmpDir);
            if (!Directory.Exists(tmpDir))
                Directory.CreateDirectory(tmpDir);
            else
                foreach (string file in Directory.GetFiles(tmpDir))
                    File.Delete(file);
            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();
            for (int i = 0; i < rndNum; i++)
            {
                string fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }
            return files.ToArray();
        }

        [TestMethod()]
        public void FileLineCountTest()
        {
            int linecount;
            int charcount;
            string filepath = GetTestFile(out linecount, out charcount);
            Assert.AreEqual(linecount, Program.FileLineCount(filepath));
        }

        [TestMethod()]
        public void LineCountTest()
        {
            string h = "dsaas \n dsaasdsad";
            Assert.AreEqual(2, Program.LineCount(h));
            h = "Omid \n Mirza \n Jani";
            Assert.AreEqual(3, Program.LineCount(h));
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            string test1 = "ﻣﻦﻫﻤﯿﺸﻪﺳﺮوﻗﺖﻫﺴﺘﻢ";
            string test2 = "HelloWorld!";
            Assert.AreEqual(16, Program.LetterCount(test1));
            Assert.AreEqual(10, Program.LetterCount(test2));
        }

        [TestMethod()]
        public void CalculateLengthTest()
        {
            string test1 = "this is a test string";
            string test2 = "123456789";
            Assert.AreEqual(21, Program.CalculateLength(test1));
            Assert.AreEqual(9, Program.CalculateLength(test2));
        }
    }
}