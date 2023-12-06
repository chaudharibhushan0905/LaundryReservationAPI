using Microsoft.EntityFrameworkCore;
using LaundryReservationAPI.Data;
using LaundryReservationAPI.Interfaces;
using LaundryReservationAPI.Models;

namespace LaundryReservationAPI.Repositories
{
    public class MachineRepository: IMachineRepository
    {
        private readonly LaundryDbContext _laundryDbContext;
        public MachineRepository(LaundryDbContext laundryDbContext) 
        {
            _laundryDbContext = laundryDbContext;
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            return await _laundryDbContext.Machines.ToListAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            return await _laundryDbContext.Machines.FindAsync(id);
        }

        public async Task<Machine> GetMachineByNumberAsync(string machineNumber)
        {
            return await _laundryDbContext.Machines.FirstOrDefaultAsync(m => m.MachineNumber == machineNumber);

        }

        public async Task<bool> SaveChangesAsync()
        {
            int savedEntries = await _laundryDbContext.SaveChangesAsync();
            return savedEntries > 0 ? true : false;
        }

        public async Task<bool> ToggleMachineLockAsync(Machine machine)
        {
            if(machine.IsLocked)
            {
                machine.IsLocked = false;
            }
            else
            {
                machine.IsLocked = true;
            }
            _laundryDbContext.Machines.Update(machine);
            return await SaveChangesAsync();
        }
    }
}
