namespace AbstractFactory_Log
{
    public interface ITextLogger
    {
        void Log(string args);
        void Log(string args, params object[] param);

    }
}