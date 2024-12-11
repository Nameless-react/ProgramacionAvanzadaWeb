using Frontend.ApiModel;
using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface ISecurityHelper
    {
        void Logout();
        LoginAPI Login(UserViewModel user);

    }
}
