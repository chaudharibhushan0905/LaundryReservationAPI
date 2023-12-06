using System.ComponentModel.DataAnnotations;

namespace LaundryReservationAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        [EmailAddress]
        public string Email { get; set; } = "test@test.com";
        [Phone]
        public string CellPhoneNumber { get; set; } = "";
        public string Pin {  get; set; }
        public bool IsUsed { get; set; }
        public bool IsCanceled { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        //Used by Model Builder
        private Reservation() { }
        public Reservation(
            DateTime reservationDateTime,
            string email,
            string cellPhoneNumber,
            string pin,
            bool isUsed,
            bool isCanceled,
            int machineId)
        {
            ReservationDateTime = reservationDateTime;
            Email = email;
            CellPhoneNumber = cellPhoneNumber;
            Pin = pin;
            IsUsed = isUsed;
            IsCanceled = isCanceled;
            MachineId = machineId;
        }
    }
}
