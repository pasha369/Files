using System;

namespace Builder_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            IReportBuilder html = new HtmlBuilder(@"c:\report.html");
            IReportBuilder text = new TextBuilder(@"c:\report.txt");

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter number od marks: ");
            int numMarks = Convert.ToInt32(Console.ReadLine());
            int[] marks = new int[numMarks];

            Console.WriteLine("Enter {0} mark: ", numMarks);
            for(int i = 0; i < marks.Length; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Create report: \n1. Html report \n2. Text report");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReportCreator htmlCreator = new ReportCreator(html);
                    htmlCreator.CreateReport(name, GetAvg(marks), GetMin(marks), GetMax(marks));
                    htmlCreator.GetReport();
                    break;
                case "2":
                    ReportCreator textCreator = new ReportCreator(text);
                    textCreator.CreateReport(name, GetAvg(marks), GetMin(marks), GetMax(marks));
                    textCreator.GetReport();
                    break;
            }
        }

        public static int GetAvg(int[] arr)
        {
            var sum = 0;
            foreach (var i in arr)
            {
                sum += i;
            }
            int avg = sum/arr.Length;
            return avg;
        }
        public static int GetMin(int[] arr)
        {
            var min = arr[0];
            foreach (var i in arr)
            {
                if(i < min)
                {
                    min = i;
                }
            }
            return min;
        }
        public static int GetMax(int[] arr)
        {
            var max = arr[0];
            foreach(var i in arr)
            {
                if(i > max)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
