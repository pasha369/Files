namespace AbstractFactory_Log
{
    interface IDBLogger
    {
        void Log(string args);
        void Log(string args, params object[] param);
    }
}