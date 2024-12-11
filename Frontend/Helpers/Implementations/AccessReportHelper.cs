using Frontend.ApiModel;
using Frontend.Helpers.Interface;  
using Frontend.Models;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Threading.Tasks;

namespace Frontend.Helpers.Implementations

{
    public class AccessReportHelper : IAccessReportHelper
    {
        private readonly IServiceRepository _serviceRepository;


        public AccessReportHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        AccessReport Convert(AccessReportViewModel accessReportViewModel)
        {
            return new AccessReport
            {

               AccessReportId = accessReportViewModel.AccessReportID,
               ClientID = accessReportViewModel.ClientID,
               AccessDate = accessReportViewModel.AccessDate,
               IPAddress = accessReportViewModel.IPAddress,
               Success = accessReportViewModel.Success,
               AccessDescription =accessReportViewModel.AccessDescription


            };
        }

        AccessReportViewModel Convert(AccessReport accessReport)
        {
            return new AccessReportViewModel
            {

                AccessReportID = accessReport.AccessReportId,
                ClientID = accessReport.ClientID,
                AccessDate = accessReport.AccessDate,
                IPAddress = accessReport.AccessDescription,
                Success = accessReport.Success,
                AccessDescription = accessReport.AccessDescription


            };
        }


        public List<AccessReportViewModel> GetAllReports()
        {

            _serviceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/AccessReport");
            List<AccessReport> accessReports = new List<AccessReport>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                accessReports = JsonConvert.DeserializeObject<List<AccessReport>>(content);
            }

            List<AccessReportViewModel> result = new List<AccessReportViewModel>();
            foreach (var item in accessReports)
            {
                result.Add(Convert(item));
                    
            }
            return result;
        }

        public AccessReportViewModel GetReport(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/AcessReport/" + id.ToString());
            AccessReport accessReport = new AccessReport();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                accessReport = JsonConvert.DeserializeObject<AccessReport>(content);
            }

            AccessReportViewModel result = Convert(accessReport);
            return result;
        }


    }
}
