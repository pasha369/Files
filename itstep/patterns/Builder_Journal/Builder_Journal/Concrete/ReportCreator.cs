namespace Builder_Journal
{
    class ReportCreator
    {
        private IReportBuilder reportBuilder { set; get; }
        
        public ReportCreator(IReportBuilder builder)
        {
            reportBuilder = builder;
        }

        public void CreateReport(string name, int avgMark, int minMark, int maxMark)
        {
            reportBuilder.SetBody();
            reportBuilder.SetName(name);
            reportBuilder.SetAvgMark(avgMark);
            reportBuilder.SetMinMark(minMark);
            reportBuilder.SetMaxMark(maxMark);
            reportBuilder.Save();
        }
        public void GetReport()
        {
            reportBuilder.GetReport();
        }
    }
}