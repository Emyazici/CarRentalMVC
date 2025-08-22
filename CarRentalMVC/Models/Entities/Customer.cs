using System.Reflection.PortableExecutable;

namespace CarRentalMVC.Models.Entities
{
    public class Customer : User
    {
        public string DriverLicenseNo { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
