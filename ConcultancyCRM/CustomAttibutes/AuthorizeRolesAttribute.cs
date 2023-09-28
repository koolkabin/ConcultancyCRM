using ConcultancyCRM.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace ConcultancyCRM.CustomAttibutes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = roles.QuickJoin();
        }
    }
}
