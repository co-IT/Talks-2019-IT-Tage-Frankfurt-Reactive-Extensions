using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartGateIn.Properties;
using System;

namespace SmartGateIn.SapWebservices
{
    internal class GateInService : IGateInService
    {
        public IObservable<GateInInstructions> GetInstructionsFor(IEnumerable<string> scans)
        {
            return Observable
                .FromAsync(() => GetValueSimulatingTypicalWebserviceCall(scans));
        }

        private async Task<GateInInstructions> GetValueSimulatingTypicalWebserviceCall(IEnumerable<string> scan)
        {
            using (var client = new BackendClient().Connect())
            {
                var bar = scan.Aggregate(string.Empty, (current, next) => string.IsNullOrWhiteSpace(current) ? next : $"{current},{next}");
                var parameters = new[] { new KeyValuePair<string, string>(string.Empty, bar) };
                var content = new FormUrlEncodedContent(parameters);

                var response = client.PostAsync(Settings.Default.ScanRoute, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new IOException("Keine Verbindung zum SAP Backend");
                }

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return null;
                }

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new HttpRequestException($"Unbekannter StatusCode {response.StatusCode}");

                var contents = await response.Content.ReadAsStringAsync();
                
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GateInInstructions>(contents));
            }
        }
    }
}