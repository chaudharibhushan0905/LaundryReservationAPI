using System.ComponentModel.DataAnnotations;

namespace LaundryReservationAPI.Models.DAL
{
    public class ReservationRequest
    {
        public DateTime ReservationDateTime { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string CellPhoneNumber { get; set; }
    }
}
