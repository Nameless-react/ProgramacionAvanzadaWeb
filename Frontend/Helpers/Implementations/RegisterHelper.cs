using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class RegisterHelper : IRegisterHelper
    {
        private  IServiceRepository _serviceRepository;
        
        public RegisterHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        

        public RegisterAPI RegisterUser(RegisterViewModel user)
        {
            try
            {
                HttpResponseMessage response = _serviceRepository.PostResponse("/api/Auth/Register", new { user.Username, user.Password, user.Email, user.PhoneNumber, user.Roles });
                var content = response.Content.ReadAsStringAsync().Result;
                RegisterAPI registerAPI = JsonConvert.DeserializeObject<RegisterAPI>(content);
                return registerAPI;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
