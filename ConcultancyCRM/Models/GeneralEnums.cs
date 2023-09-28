using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConcultancyCRM.Models
{
    public enum enumUserType
    {
        SuperAdmin = 1,
        GeneralAdmin = 2,
        SalesRepresentative
    }
    public enum enumLeadStatus
    {
        Pending = 0,
        Won,
        Lost,
        Hold
    }
}
