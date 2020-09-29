using ConsoleApp.Services;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            DeviceService.deviceClient.SetMethodHandlerAsync("SetTelementryInterval", DeviceService.SetTelemetryInterval, null).Wait();
            DeviceService.sendMessageAsync().GetAwaiter();

            Console.ReadKey();
        }

    }
}
