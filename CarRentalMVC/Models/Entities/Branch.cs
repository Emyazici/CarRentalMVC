namespace CarRentalMVC.Models.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Fleet Fleet { get; set; }
        public int FleetId { get; set; } // Foreign key to Fleet
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<BranchStaff> BranchStaffs { get; set; } = new List<BranchStaff>();
        public ICollection<Reservation> ReservationsFrom { get; set; } = new List<Reservation>();
        public ICollection<Reservation> ReservationsTo { get; set; } = new List<Reservation>();
        public ICollection<DamageReport> DamageReports { get; set; } = new List<DamageReport>();
        public ICollection<VehicleAssignmentHistory> VehicleAssignmentHistoriesFrom { get; set; } = new List<VehicleAssignmentHistory>();
        public ICollection<VehicleAssignmentHistory> VehicleAssignmentHistoriesTo { get; set; } = new List<VehicleAssignmentHistory>();

    }
}
