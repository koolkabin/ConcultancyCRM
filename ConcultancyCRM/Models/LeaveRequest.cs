﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public DateTime RequestDate { get; set; }
        public string LeaveRemarks { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedByUserName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual Employee Employee { get; set; }
    }
}