using ConcultancyCRM.Extensions;
using ConcultancyCRM.Models;

namespace ConcultancyCRM.CustomAttibutes
{
    public class GeneralAdminAuthAttribute : AuthorizeRolesAttribute
    {
        public GeneralAdminAuthAttribute(params string[] roles) : base(roles.Push(enumUserType.GeneralAdmin.ToString()))
        {
        }
    }
}
