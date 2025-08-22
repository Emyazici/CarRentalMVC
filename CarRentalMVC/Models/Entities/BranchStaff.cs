namespace CarRentalMVC.Models.Entities
{
    public class BranchStaff : Staff
    {
        public Branch Branch { get; set; }
        public int BranchId { get; set; } // Foreign key to Branch
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<DamageReport> DamageReports { get; set; } = new List<DamageReport>();
    }
}
