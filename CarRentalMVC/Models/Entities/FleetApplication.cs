using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models.Entities
{
    public class FleetApplication
    {
        public int Id { get; set; }
        public string ContactPhone { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public string? RejectionReason { get; set; }
        public DateTime CreatedAt { get; set; }

        // Başvuran (FleetOwner rolündeki kullanıcı)
        public int ApplicantUserId { get; set; }
        public User ApplicantUser { get; set; } = null!;
        public Fleet? Fleet { get; set; }
        public int? FleetId { get; set; }

        public Admin? Admin { get; set; }
        public int? AdminId { get; set; }
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
