using ConcultancyCRM.StaticHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class LeadInfo
    {
        public int Id { get; set; }
        public DateTime TxnDate { get; set; } = DateTime.Now;
        [MaxLength(255)]
        public string LeadSource { get; set; }
        [MaxLength(255)]
        public string AgentName { get; set; }
        [MaxLength(255)]
        public string CandidateFirstName { get; set; }
        [MaxLength(255)]
        public string CandidateLastName { get; set; }
        [MaxLength(255)]
        public string PhoneNo { get; set; }
        [MaxLength(255)]
        public string EmailID { get; set; }
        [MaxLength(255)]
        public string Country { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(255)]
        public string Result { get; set; }
        [MaxLength(255)]
        public string VendorName { get; set; }
        [MaxLength(255)]
        public string VendorID { get; set; }
        [MaxLength(255)]
        public string ExamCode { get; set; }
        [MaxLength(255)]
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        [MaxLength(255)]
        public string ExamMonth { get; set; }
        public int ExamYear { get; set; }
        [MaxLength(255)]
        public string ExamType { get; set; }
        [MaxLength(255)]
        public string CenterName { get; set; }
        [MaxLength(255)]
        public string CenterAddress { get; set; }
        [MaxLength(255)]
        public string CenterCountry { get; set; }
        [MaxLength(255)]
        public string CenterPhoneNo { get; set; }
        [MaxLength(255)]
        public string CreditCard { get; set; }
        [MaxLength(255)]
        public string Currency { get; set; }
        public decimal PaidFeeAmount { get; set; }
        [MaxLength(255)]
        public string VoucherNumber { get; set; }
        [MaxLength(255)]
        public string Delivery { get; set; }
        [UIHint("LeadStatus")]
        public enumLeadStatus LeadStatus { get; set; } = enumLeadStatus.Pending;
        public virtual ICollection<AssignedLeads> AssignedLeads { get; set; }
        public virtual ICollection<LeadComments> LeadComments { get; set; }


        [NotMapped]
        public AssignedLeads LastRecord => AssignedLeads.Any() ? AssignedLeads.Last() : new AssignedLeads();
        //[NotMapped]
        public bool CanComment(SessionInfo _ActiveSession) => IsLeadActive &&
            (_ActiveSession.IsGeneralAdmin || LastRecord.EmployeeId == _ActiveSession.EmployeeId);
        [NotMapped]
        public bool IsLeadComplete => LeadStatusHelper.IsLeadCompleted(LeadStatus);
        [NotMapped]
        public bool IsLeadActive => LeadStatusHelper.IsActive(LeadStatus);
        //[NotMapped]
        public bool CanAssignLead(SessionInfo _ActiveSession) => _ActiveSession.IsGeneralAdmin &&
            IsLeadActive;
        public bool CanEdit(SessionInfo _ActiveSession) => _ActiveSession.IsGeneralAdmin &&
           IsLeadActive;
        public bool CanDelete(SessionInfo _ActiveSession) => _ActiveSession.IsGeneralAdmin &&
          IsLeadActive;

        public LeadInfo()
        {
            AssignedLeads = new HashSet<AssignedLeads>();
            LeadComments = new HashSet<LeadComments>();
        }
    }
}