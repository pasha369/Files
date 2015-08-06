using System;
using System.Diagnostics;
using System.IO;

namespace Builder_Journal
{
    class TextBuilder:IReportBuilder
    {
        private Report report;

        public TextBuilder(string path)
        {
            report = new Report();
            report.path = path;
        }

        private void WriteToFile(string input)
        {
            if (File.Exists(report.path))
            {
                using (StreamWriter sw = File.CreateText(report.path))
                {
                    sw.WriteLine(input);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(report.path))
                {
                    sw.WriteLine(input);
                }
            }
        }

        public void SetBody(){}

        public void SetName(string name)
        {
            WriteToFile(string.Format("Student: {0}", name));
            WriteToFile("---------------------------------");
        }

        public void SetAvgMark(int avgMark)
        {
            WriteToFile(string.Format("Avarage mark: {0}", avgMark));
        }

        public void SetMinMark(int minMark)
        {
            WriteToFile(string.Format("Minimum mark: {0}", minMark));
        }

        public void SetMaxMark(int maxMark)
        {
            WriteToFile(string.Format("Max mark: {0}", maxMark));
            WriteToFile("---------------------------------");
        }

        public void Save(){}

        public void GetReport()
        {
            /*
            using (StreamReader streamReader = new StreamReader(report.path))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.Read();
             * */

            Process.Start("notepad.exe", report.path);
        }
    }
}