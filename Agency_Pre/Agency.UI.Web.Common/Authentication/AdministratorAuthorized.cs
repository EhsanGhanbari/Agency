using System.Web.Http;

namespace Agency.UI.Web.Common.Authentication
{
    public class AdministratorAuthorized : AuthorizeAttribute
    {
        public AdministratorAuthorized()
        {
            Roles = "Administrators";
        }
    }
}