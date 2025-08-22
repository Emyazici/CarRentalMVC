namespace CarRentalMVC.Models.Entities
{
    public class Admin : User
    {
        public ICollection<FleetApplication> FleetApplications { get; set; } = new List<FleetApplication>();
        public ICollection<Fleet> Fleets { get; set; } = new List<Fleet>();
    }
}
