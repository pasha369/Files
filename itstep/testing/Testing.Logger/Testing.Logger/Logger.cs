using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Logger
{
    public class TextLogger :ILogger
    {
        public DateTime GetCurrentTime()
        {
            var date = DateTime.Now.Date;
            return date;
        }

        public void Save(string path)
        {
            var date = GetCurrentTime();

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(String.Format("{0}: test log", date));
                
            }
        }
    }
}
