namespace ConcultancyCRM.Models
{
    public static class LeadStatusHelper
    {
        public static enumLeadStatus[] CompletedLeadSatus { get; } = new enumLeadStatus[]{
            enumLeadStatus.Won, enumLeadStatus.Lost
        };
        public static enumLeadStatus[] ActiveLeadStatus { get; } = new enumLeadStatus[]{
            enumLeadStatus.Pending
        };
        public static bool IsLeadCompleted(enumLeadStatus enumLeadStatus) => CompletedLeadSatus.Contains(enumLeadStatus);
        public static bool IsActive(enumLeadStatus enumLeadStatus) => !CompletedLeadSatus.Contains(enumLeadStatus);
    }
}
