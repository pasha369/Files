namespace AbstractFactory_Log
{
    interface ILogFactory
    {
        ITextLogger GetTextLogger();
        IXMLLogger GetXmlLogget();
        IDBLogger GetDbLogger();
    }
}