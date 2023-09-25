namespace ConcultancyCRM.StaticHelpers
{
    public class SessionInfo
    {
        public string Id { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string EmpName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public IList<string> AssociatedRoles { get; set; }
    }
}
