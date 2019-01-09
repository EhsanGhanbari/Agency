using System;

namespace Agency.UI.Web.Common.Authentication
{
    public class MembershipUserWrapper
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}