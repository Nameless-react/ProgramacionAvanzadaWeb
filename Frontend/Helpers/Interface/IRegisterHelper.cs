using Frontend.ApiModel;
using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface IRegisterHelper
    {   
        RegisterAPI RegisterUser(RegisterViewModel user);
    }
}
