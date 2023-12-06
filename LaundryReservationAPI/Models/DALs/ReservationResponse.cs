using System.ComponentModel.DataAnnotations;

namespace LaundryReservationAPI.Models.DAL
{
    public class ReservationResponse
    {
        public string MachineNumber { get; set; }
        [StringLength(5)]
        public string Pin { get; set; }
    }
}
