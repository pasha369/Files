using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Logger
{
    public class LogSaver
    {
        public void WriteLog(ILogger logger, string path)
        {
            logger.Save(path);
        }
    }
}
