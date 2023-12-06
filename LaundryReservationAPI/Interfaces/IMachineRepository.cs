

using LaundryReservationAPI.Models;

namespace LaundryReservationAPI.Interfaces
{
    public interface IMachineRepository
    {
        Task<Machine> GetMachineByIdAsync(int id);
        Task<Machine> GetMachineByNumberAsync(string machineNumber);
        Task<IEnumerable<Machine>> GetAllMachinesAsync();
        Task<bool> ToggleMachineLockAsync(Machine machine);
        Task<bool> SaveChangesAsync();
    }
}
