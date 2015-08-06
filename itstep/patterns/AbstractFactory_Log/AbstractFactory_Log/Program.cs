using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Log
{
    class LogFactory: ILogFactory
    {
        public ITextLogger GetTextLogger()
        {
            return new TextLogger();
        }

        public IXMLLogger GetXmlLogget()
        {
            return new XMLLogger();
        }

        public IDBLogger GetDbLogger()
        {
            return new DBLogger();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            ITextLogger log = new TextLogger();

            log.Log("\ntest\n");
            log.Log("\ntest {0} - method{1}\n", 1, 2);
             */

            /*
            IXMLLogger log = new XMLLogger();

            log.Log("\ntest\n");
            log.Log("\ntest {0} - method{1}\n", 1, 2);
             */
            LogFactory logFactory = new LogFactory();

            Console.WriteLine("Enter logger message: ");
            var str = Console.ReadLine();

            Console.WriteLine("Choose logger type: ");
            Console.Write("\n1. XML \n2. Text \n3. Database\n");

            int choice = Convert.ToInt32(Console.ReadLine());

            var dbLogger = logFactory.GetDbLogger();
            var textLogger = logFactory.GetTextLogger();
            var xmlLogger = logFactory.GetXmlLogget();

            switch (choice)
            {
                case 1:
                    xmlLogger.Log(str);
                    xmlLogger.Log("{0}", str);
                    break;
                case 2:
                    textLogger.Log(str);
                    textLogger.Log("{0}", str);
                    break;
                case 3:
                    dbLogger.Log(str);
                    dbLogger.Log("{0}", str);
                    break;
            }

        }
    }
}
