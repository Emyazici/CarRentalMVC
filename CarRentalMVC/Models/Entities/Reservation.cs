using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending"; // 'Pending, Confirmed, Cancelled, Completed'
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int FromBranchId { get; set; }
        public Branch FromBranch { get; set; }

        public int ToBranchId { get; set; }
        public Branch ToBranch { get; set; }

        public int CreatedById { get; set; } // Nullable in case the reservation is not handled by a staff member
        public BranchStaff CreatedBy { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
