using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models.Entities
{
    public class DamageReport
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // 'Pending, InProgress, Resolved, Rejected'
        
        // Navigation properties
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        public int CreatedById { get; set; }
        public BranchStaff CreatedBy { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
