using StroiTrendTestTask.Server.Model;

namespace StroiTrendTestTask.Server.Services.Interface
{
    public interface IReportService
    {
        Report GetReportAsync (string name);
    }
}
