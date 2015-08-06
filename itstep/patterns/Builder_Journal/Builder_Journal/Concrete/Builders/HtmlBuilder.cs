using System.Xml;

namespace Builder_Journal
{
    class  HtmlBuilder:IReportBuilder
    {
        private Report report;
        private XmlDocument xmlDocument;

        public HtmlBuilder(string path)
        {
            report = new Report();
            xmlDocument = new XmlDocument();

            report.path = path;
        }
        public void SetBody()
        {
            XmlElement html = xmlDocument.CreateElement("html");
            XmlElement body = xmlDocument.CreateElement("body");
            body.SetAttribute("style", "text-align: center;");
            html.AppendChild(body);
            xmlDocument.AppendChild(html);
        }

        public void SetName(string name)
        {
            XmlNode body = xmlDocument.FirstChild.FirstChild;
            XmlElement _name = xmlDocument.CreateElement("h1");
            
            _name.InnerText = name;
            body.AppendChild(_name);

            XmlElement line = xmlDocument.CreateElement("hr");
            line.SetAttribute("style", "width: 50%;");
            body.AppendChild(line);
        }

        public void SetAvgMark(int avgMark)
        {
            XmlNode body = xmlDocument.FirstChild.FirstChild;
            XmlElement _average = xmlDocument.CreateElement("div");
            _average.SetAttribute("style", "font-style:italic;");
            _average.InnerText = string.Format("Average mark: {0}", avgMark);
            body.AppendChild(_average);
        }

        public void SetMinMark(int minMark)
        {
            XmlNode body = xmlDocument.FirstChild.FirstChild;
            XmlElement _minimum = xmlDocument.CreateElement("div");
            _minimum.SetAttribute("style", "font-style:italic;");
            _minimum.InnerText = string.Format("Minimum mark: {0}", minMark);
            body.AppendChild(_minimum);
        }

        public void SetMaxMark(int maxMark)
        {
            XmlNode body = xmlDocument.FirstChild.FirstChild;
            XmlElement _maximum = xmlDocument.CreateElement("div");
            _maximum.SetAttribute("style", "font-style:italic;" );
            _maximum.InnerText = string.Format("Maximum mark: {0}", maxMark);
            body.AppendChild(_maximum);
        }

        public void Save()
        {
            xmlDocument.Save(report.path);
        }

        public void GetReport()
        {
            System.Diagnostics.Process.Start(report.path);
        }
    }
}