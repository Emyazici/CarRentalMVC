using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models.Entities
{
    public class VehicleAssignmentHistory
    {
        public int Id { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Assigned"; // 'Assigned, Returned, Cancelled'
        
        // Navigation properties
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int FromBranchId { get; set; }
        public Branch FromBranch { get; set; }

        public int ToBranchId { get; set; }
        public Branch ToBranch { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
