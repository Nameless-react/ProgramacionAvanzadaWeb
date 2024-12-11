using Frontend.ApiModel;
using FrontEnd.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using Frontend.Helpers.Interface;

namespace Frontend.Helpers.Implementations
{
    public class SecurityHelper : ISecurityHelper
    {
        IServiceRepository ServiceRepository;
        public SecurityHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;

        }

        public void Logout()
        {
            try
            {
                HttpResponseMessage response = ServiceRepository.PostResponse("/api/Auth/Logout", new {});
                var content = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public LoginAPI Login(UserViewModel user)
        {
            try
            {
                HttpResponseMessage response = ServiceRepository.PostResponse("/api/Auth/Login", new { user.UserName, user.Password });
                var content = response.Content.ReadAsStringAsync().Result;
                LoginAPI loginAPI = JsonConvert.DeserializeObject<LoginAPI>(content);
                return loginAPI;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
