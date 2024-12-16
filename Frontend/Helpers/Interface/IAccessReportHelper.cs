using Frontend.Models;
using System.Collections.Generic;
using Frontend.ApiModel;


namespace Frontend.Helpers.Interface
{
    public interface IAccessReportHelper
    {
        List<AccessReportViewModel> GetAllReports();
        string Token { get; set; }
        AccessReportViewModel GetReport(int id);
       
        AccessReportViewModel Add(AccessReportViewModel access);
    }
}
