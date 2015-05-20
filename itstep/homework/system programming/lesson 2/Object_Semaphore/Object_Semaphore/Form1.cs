using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_Semaphore
{
    public partial class Form1 : Form
    {
        private readonly object syncObject = new object(); 

        Semaphore s = new Semaphore(3,3,"semaphore");
        List<Thread> CreatedThreads = new List<Thread>();
        List<Thread> WaitedThreads = new List<Thread>();
        List<Thread> WorkedThreads = new List<Thread>();
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int i = 0;
            ThreadStart threadStart = new ThreadStart(task);
            Thread thread = new Thread(threadStart);

            thread.Name = "thread " + idx;
            idx++;

            CreatedThreads.Add(thread);
            listViewCreate.Items.Add(thread.Name);



        }

        private void task()
        {
            while (true)
            {
              Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());   
            }
        }

        public static int idx { get; set; }

        private void listViewCreate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = 0;
            int index = listViewCreate.Items.IndexOf((listViewCreate.SelectedItems[0]));

            listViewCreate.Items.Remove(listViewCreate.Items[index]);

            Thread thread = CreatedThreads[index];

            CreatedThreads.Remove(thread);
            WaitedThreads.Add(thread);

            listViewWait.Items.Clear();

            foreach (var thrd in WaitedThreads)
            {
                i++;
                listViewWait.Items.Add("Thread" + i);
            }

            ThreadStart start = new ThreadStart(AddToRun);
            Thread back_thread = new Thread(start);

            back_thread.Start();
        }

        private delegate void AddItemCallback(object o);
        private void AddToRun()
        {
            s.WaitOne();

            int i = 0;
            lock (syncObject){
                if (this.listViewWork.InvokeRequired )
                {
                    listViewWork.Invoke((MethodInvoker) delegate { listViewWork.Items.Clear(); });

                    WorkedThreads.Add(WaitedThreads.First());
                    WaitedThreads.Remove(WaitedThreads.First());
                }
            }
            lock (syncObject)
            {
                foreach (var thread in WorkedThreads)
                {
                    i++;
                    if (this.listViewWork.InvokeRequired)
                    {
                        AddItemCallback d = new AddItemCallback(AddItem);
                        this.Invoke(d, new object[] { ("Thread" + i) });
                    }
                    //listViewWork.Invoke(new Action<string>(listViewWork.Items.Add), ("Thread" + i));
                }
            }

            

            s.Release(1);
        }

        private void AddItem(object o)
        {
            listViewWork.Items.Add(o as string);
        }
    }
}
