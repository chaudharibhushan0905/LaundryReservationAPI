using Microsoft.AspNetCore.Mvc;
using LaundryReservationAPI.Interfaces;

namespace LaundryReservationAPI.Controllers
{
    public class MachineController : BaseController
    {
        private readonly IMachineRepository _machineRepository;
        public MachineController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }
        [HttpGet]
        [Route("[controller]/list")]
        public async Task<IActionResult> GetAllMachinesAsync() 
        {
            return Ok(await _machineRepository.GetAllMachinesAsync());
        }

        [HttpPost]
        [Route("[controller]/lock")]
        public async Task<ActionResult<bool>> LockMachineAsync(string machineNumber)
        {
            var machineDetails = await _machineRepository.GetMachineByNumberAsync(machineNumber);
            if (machineDetails == null)
            {
                return Ok(false);
            }
            //check if machine is already locked then return false => i.e, Machine can not be locked as already locked.
            if (machineDetails.IsLocked)
            {
                return Ok(false);
            }
            var isLockedSuccessfully = await _machineRepository.ToggleMachineLockAsync(machineDetails);
            if (!isLockedSuccessfully)
            {
                return Ok(isLockedSuccessfully);
            }
            return Ok(isLockedSuccessfully);
        }

        [HttpPost]
        [Route("[controller]/unlock")]
        public async Task<ActionResult<bool>> UnlockMachineAsync(string machineNumber)
        {
            var machineDetails = await _machineRepository.GetMachineByNumberAsync(machineNumber);
            if (machineDetails == null)
            {
                return Ok(false);
            }
            //check if machine is already unlocked then return false => i.e, Machine can not be unlocked as already unlocked.
            if (!machineDetails.IsLocked)
            {
                return Ok(false);
            }
            var isUnlockedSuccessfully = await _machineRepository.ToggleMachineLockAsync(machineDetails);
            if(!isUnlockedSuccessfully)
            {
                return Ok(isUnlockedSuccessfully);
            }
            return Ok(isUnlockedSuccessfully);
        }
    }
}
