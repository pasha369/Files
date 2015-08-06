namespace Builder_Journal
{
    interface IReportBuilder
    {
        void SetBody();
        void SetName(string name);
        void SetAvgMark(int avgMark);
        void SetMinMark(int minMark);
        void SetMaxMark(int maxMark);
        void Save();
        void GetReport();
    }
}