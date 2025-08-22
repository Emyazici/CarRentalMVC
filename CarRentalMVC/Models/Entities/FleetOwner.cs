using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models.Entities
{
    public class FleetOwner : User
    {
        public bool IsApproved { get; set; } = false;

        // Başvuran (FleetOwner rolündeki kullanıcı)
        public Fleet? Fleet { get; set; }
        public int? FleetId { get; set; }
    }
}
