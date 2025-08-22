namespace CarRentalMVC.Models.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; } // Manuel or Automatic
        public string FuelType { get; set; } //Diesel - Electric - Hybrid - Gasoline
        public string Plate { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Status { get; set; } = "Available"; // 'Available, Maintenance, Reserved, Inactive'
        public decimal DailyPrice { get; set; } = 1500; // Default daily price in Turkish Lira (TRY)
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastMaintenanceDate { get; set; }
        public string? ImageUrl { get; set; }
        // Navigation properties
        public int FleetId { get; set; }
        public Fleet Fleet { get; set; }
        public Branch Branch { get; set; }
        public int BranchId { get; set; } // Foreign key to Branch
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<DamageReport> DamageReports { get; set; } = new List<DamageReport>();
        public ICollection<VehicleAssignmentHistory> VehicleAssignmentHistories { get; set; } = new List<VehicleAssignmentHistory>();
    }
}
