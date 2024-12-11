using Frontend.Models;
using System.Collections.Generic;
using Frontend.ApiModel;


namespace Frontend.Helpers.Interface
{
    public interface IAccessReportHelper
    {
        List<AccessReportViewModel> GetAllReports();

        AccessReportViewModel GetReport(int id);
       
    }
}
