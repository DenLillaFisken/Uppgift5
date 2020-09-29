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

        [Theory]
        [InlineData("SetTelementryInterval", "10", 200)]
        [InlineData("SetInterval", "10", 501)]

        public void SetTelementryInterval_ShouldChangeTheInterval(string methodName, string payload, int statusCode)
        {
            var response = DeviceService.SetTelemetryInterval(new MethodRequest(methodName), null).GetAwaiter().GetResult();

            //var responseData = Encoding.UTF8.GetString(response.Result);

            
            Assert.Equal(statusCode, response.Status);
            //Assert.Equal(payload, responseData);

        }
    }
}
