using ConcultancyCRM.Extensions;
using ConcultancyCRM.Models;

namespace ConcultancyCRM.CustomAttibutes
{
    public class SalesRepresentativeAuthAttribute : AuthorizeRolesAttribute
    {
        public SalesRepresentativeAuthAttribute(params string[] roles) : base(roles.Push(enumUserType.SalesRepresentative.ToString()))
        {
        }
    }
}
