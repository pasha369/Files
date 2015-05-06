using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sys_homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Money = 2000;
            bank.Name = "pasha";
            bank.Percent = 1000;
        }

        public class Bank
        {
            private int money;
            public int Money{set{
                money = value;
                create_thread();
            }
                get { return money; }
            }
            private string name;
            public string Name
            {
                set
                {
                    name = value;
                    create_thread();
                }
                get { return name; }
            }
            public int percent;
            public int Percent
            {
                set
                {
                    percent = value;
                    create_thread();
                }
                get { return percent; }
            }

            public void create_thread()
            {
                ThreadStart threadStart = new ThreadStart(write_to_file);
                Thread thread_write = new Thread(threadStart);
                thread_write.Start();
                thread_write.Join();
            }

            public void write_to_file()
            {
                StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "\\bank.txt", true);
                file.WriteLine("money: "+money);
                file.WriteLine("name: " + name);
                file.WriteLine("percent: " + percent);
                file.WriteLine("---------------------");
                file.Close();
            }
        }
    }
}
