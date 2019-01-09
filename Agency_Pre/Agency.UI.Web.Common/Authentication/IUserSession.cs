using System;

namespace Agency.UI.Web.Common.Authentication
{
    public interface IUserSession
    {
        Guid UserId { get; }
        string Firstname { get; }
        string Lastname { get; }
        string Username { get; }
        string Email { get; }
    }
}