using System.Xml;

namespace AbstractFactory_Log
{
    class XMLLogger: IXMLLogger
    {
        private string _path = @"c:\log.xml";

        public void Log(string args)
        {
            using (XmlTextWriter objXmlWritter = new XmlTextWriter(_path, null))
            {
                objXmlWritter.Formatting = Formatting.Indented;
                objXmlWritter.WriteStartDocument();
                objXmlWritter.WriteStartElement("Message");

                objXmlWritter.WriteString(args);

                objXmlWritter.WriteEndElement();
                objXmlWritter.WriteEndDocument();
            }
        }

        public void Log(string args, params object[] param)
        {
            using (XmlTextWriter objXmlWritter = new XmlTextWriter(_path, null))
            {
                objXmlWritter.Formatting = Formatting.Indented;
                objXmlWritter.WriteStartDocument();
                objXmlWritter.WriteStartElement("Message");

                objXmlWritter.WriteString(string.Format(args, param));

                objXmlWritter.WriteEndElement();
                objXmlWritter.WriteEndDocument();
            }
        }
    }
}