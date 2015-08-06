namespace AbstractFactory_Log
{
    interface IXMLLogger
    {
        void Log(string args);
        void Log(string args, params object[] param);
    }
}