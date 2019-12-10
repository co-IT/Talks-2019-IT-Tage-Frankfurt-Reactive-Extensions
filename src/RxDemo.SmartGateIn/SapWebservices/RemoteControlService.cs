using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SmartGateIn.Properties;

namespace SmartGateIn.SapWebservices
{
    internal class RemoteControlService : IReceiveLockCommands
    {
        public async Task<bool> ShouldLockClientAsync()
        {
            try
            {
                using (var client = new BackendClient().Connect())
                { 
                    var response = await client.GetAsync(Settings.Default.StatusRoute);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new IOException("Keine Verbindung zum SAP Backend");
                    }
                    
                    return await response.Content.ReadAsAsync<bool>();
                }
            }
            catch ( Exception )
            {
                return await Task.FromResult(true);
            }
        }
    }
}