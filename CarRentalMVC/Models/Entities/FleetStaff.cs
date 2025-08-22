namespace CarRentalMVC.Models.Entities
{
    public class FleetStaff : Staff
    {
        public Fleet Fleet { get; set; }
        public int FleetId { get; set; } // Foreign key to Fleet
    }
}
