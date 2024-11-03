using Microsoft.AspNetCore.Identity;

namespace WalkthroughApp.Models
{
    public class Walkthrough
    {
        public int Id { get; set; }
        public DateOnly CheckDate { get; set; }
        public string Species { get; set; }
        public string shift { get; set; }
        public TimeOnly CheckTime { get; set; }
        public string Compliant { get; set; } // Yes, No
        public string Status { get; set; } // Open, Closed
        public string Comments { get; set; }
        public string CorrectiveAction { get; set; }
        public int DepartmentId { get; set; }
        public string IdentityUserId { get; set; }
        public int ProcedureId { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public Procedure Procedure { get; set; }
    }
}
