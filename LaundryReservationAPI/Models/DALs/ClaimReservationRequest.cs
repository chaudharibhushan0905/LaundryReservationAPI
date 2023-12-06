using System.ComponentModel.DataAnnotations;

namespace LaundryReservationAPI.Models.DAL
{
    public class ClaimReservationRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string CellPhoneNumber { get; set; }
        [StringLength(5)]
        public string Pin { get; set; }
    }
}
