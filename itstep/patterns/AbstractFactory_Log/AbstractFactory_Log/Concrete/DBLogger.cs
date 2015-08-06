using System;

namespace AbstractFactory_Log
{
    class DBLogger: IDBLogger
    {
        public void Log(string args)
        {
            var log = new Log();

            log.Message = args;
            log.Time = DateTime.Now;

            using (LogDBContext context = new LogDBContext())
            {
                context.logs.Add(log);
                context.SaveChanges();
            } 
        }

        public void Log(string args, params object[] param)
        {
            var log = new Log();

            log.Message = string.Format(args, param);
            log.Time = DateTime.Now;

            using (LogDBContext context = new LogDBContext())
            {
                context.logs.Add(log);
                context.SaveChanges();
            } 
        }
    }
}