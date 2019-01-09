using System;
using MVC4ServicesBook.Web.Common.Security;

namespace Agency.UI.Web.Common.Authentication
{
    public interface IMembershipInfoProvider
    {
        MembershipUserWrapper GetUser(string username);
        MembershipUserWrapper GetUser(Guid userId);
        MembershipUserWrapper CreateUser(string username, string password, string email);
        bool ValidateUser(string username, string password);
        string[] GetRolesForUser(string username);
    }
}