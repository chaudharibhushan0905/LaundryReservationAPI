using LaundryReservationAPI.Models;

namespace LaundryReservationAPI.Proxies
{
    public class MachineApiResponsePayload
    {
        public List<Machine> Machines { get; set; }
        public MachineApiResponsePayload() { }
    }
}
