using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models.Entities
{
    public class Fleet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        //Admin 1-many
        public Admin? ApprovedByAdmin { get; set; }
        public int? ApprovedByAdminId { get; set; }

        // Fleet Owner 1-1
        public FleetOwner? FleetOwner { get; set; }

        // FleetApplication 1-1
        public FleetApplication? FleetApplication { get; set; }

        // Branches 1-many
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();

        // Vehicles 1-many
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        // FleetStaff 1-many
        public ICollection<FleetStaff> FleetStaffs { get; set; } = new List<FleetStaff>();


    }
}
