using Frontend.ApiModel;
using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface ISecurityHelper
    {

        LoginAPI Login(UserViewModel user);

    }
}
