using System;
using System.IO;

namespace AbstractFactory_Log
{
    class TextLogger: ITextLogger
    {
        public void Log(string args)
        {
            string path = @"c:\log.txt";
            if(!File.Exists(path))
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    file.Write(args);
                }    
            }
            else
            {
                using (StreamWriter file = File.AppendText(path))
                {
                    file.Write(args);
                }    
            }
            
        }

        public void Log(string args, params object[] param)
        {
            string path = @"c:\log.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    file.Write(String.Format(args, param));
                }
            }
            else
            {
                using (StreamWriter file = File.AppendText(path))
                {
                    file.Write(String.Format(args, param));
                }
            }
        }
    }
}