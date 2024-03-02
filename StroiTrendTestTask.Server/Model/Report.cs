using Newtonsoft.Json;
namespace StroiTrendTestTask.Server.Model
{
    public class Report
    {
        public string Name { get; set; }
        public Request Request { get; set; }
        public double Total { get; set; }
        public Dictionary<string, Dictionary<string, double>> Records { get; set; }
    }
}