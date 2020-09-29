using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class DeviceService
    {
        public static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=EC-WEB20-AJ.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=FQFt0u9cyO0SEDTU7+zDQHAogBVuOPeag2O49QiDaPw=", TransportType.Mqtt);
        public static int telemetricInterval = 10;
        public static Random rnd = new Random();

        public static Task<MethodResponse> SetTelemetryInterval(MethodRequest request, object userContext)
        {
            
            var payload = Encoding.UTF8.GetString(request.Data).Replace("\"", "");
  
            if (Int32.TryParse(payload, out telemetricInterval))
            {
                Console.WriteLine($"Direct Method message recieved. Interval set to: {telemetricInterval}");
                string json = "{\"result\": \"Executed direct method: " + request.Name + "\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 200));
            }
            else
            {
                string json = "{\"result\": \"Method not implemented\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 501));
            }
        }

        public static async Task sendMessageAsync()
        {
            while (true)
            {
                double temp = 10 + rnd.NextDouble() * 15;
                double hum = 30 + rnd.NextDouble() * 12;

                var data = new
                {
                    temperature = temp,
                    humidity = hum
                };
                var json = JsonConvert.SerializeObject(data);
                var payload = new Message(Encoding.UTF8.GetBytes(json));
                payload.Properties.Add("temperatureAlert", (temp > 30) ? "true" : "false");

                await deviceClient.SendEventAsync(payload);
                Console.WriteLine($"Message sent: {json}");

                await Task.Delay(telemetricInterval * 1000);
            }

        }

    }
}
