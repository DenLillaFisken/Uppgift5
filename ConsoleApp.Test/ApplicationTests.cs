using ConsoleApp.Services;
using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp.Test
{
    public class ApplicationTests
    {
        private static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=EC-WEB20-AJ.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=FQFt0u9cyO0SEDTU7+zDQHAogBVuOPeag2O49QiDaPw=", TransportType.Mqtt);

        [Fact]
        //[InlineData("SetTelementryInterval", 200)]
        //[InlineData("SetInterval", 501)]

        public void SetTelementryInterval_ShouldReturnStatusCode()
        {
            var response = DeviceService.SetTelemetryInterval(new MethodRequest("SetTelementryInterval"), null).GetAwaiter().GetResult();

           var responseint = Convert.ToInt32(response.Status);

            Assert.Equal(200, responseint);

        }
    }
}
