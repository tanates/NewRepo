using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StroiTrendTestTask.Server.Model;
using StroiTrendTestTask.Server.Services.Interface;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StroiTrendTestTask.Server.Services
{
    public class ReportService: IReportService
    {
        private readonly string _folderPath = "JSONfile";


        public  Report GetReportAsync(string name)
        {
       
            var filePath = Path.Combine(_folderPath, $"{name}.json");
            string jsonText = File.ReadAllText(filePath);

            var report = JsonConvert.DeserializeObject<Report>(jsonText);
            return report;
        }

    }
}
