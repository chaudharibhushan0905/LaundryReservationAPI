namespace LaundryReservationAPI.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string MachineNumber { get; set; }
        public bool IsLocked {  get; set; }
    }
}
