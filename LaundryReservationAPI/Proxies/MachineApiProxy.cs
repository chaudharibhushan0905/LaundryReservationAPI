using Newtonsoft.Json;

namespace LaundryReservationAPI.Proxies
{
    public class MachineApiProxy:ProxyBase
    {
        private IConfiguration _configuration;
        public MachineApiProxy(HttpClient httpClient,IConfiguration configuration):base(httpClient,configuration) {
            _configuration = configuration;
        }

        public virtual async Task<string> LockMachineAsync(string machineNumber)
        {
            if (string.IsNullOrWhiteSpace(machineNumber)) { throw new ArgumentNullException($"{nameof(machineNumber)}"); }
            var query = $"api/Machine/lock?machineNumber={machineNumber}";
            var payload = await PostResourceAsync(new Uri(query, UriKind.Relative));
            return await payload.Content.ReadAsStringAsync();
        }

        public virtual async Task<string> UnlockMachineAsync(string machineNumber)
        {
            if (string.IsNullOrWhiteSpace(machineNumber)) { throw new ArgumentNullException($"{nameof(machineNumber)}"); }
            var query = $"api/Machine/unlock?machineNumber={machineNumber}";
            var payload = await PostResourceAsync(new Uri(query, UriKind.Relative));
            return await payload.Content.ReadAsStringAsync();
        }

        public virtual async Task<IEnumerable<Models.Machine>> GetMachinesAsync()
        {
            var payload = await GetResourceAsync(new Uri("api/Machine/list", UriKind.Relative), x => JsonConvert.DeserializeObject<IEnumerable<Models.Machine>>(x));
            return payload;
        }
    }
}
