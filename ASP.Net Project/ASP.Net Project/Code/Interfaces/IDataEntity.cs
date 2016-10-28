using System;

namespace ASP.Net_Project
{
    public interface IDataEntity
    {
        int ID { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Content { get; set; }
        DateTime Timestamp { get; set; }
    }
}