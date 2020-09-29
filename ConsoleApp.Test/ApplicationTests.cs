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
        [Fact]
        public void SetTelementryInterval_ShouldReturnOKStatusCode()
        {
            var array = Encoding.UTF8.GetBytes("10");
            var response = DeviceService.SetTelemetryInterval(new MethodRequest("SetTelementryInterval", array), null).GetAwaiter().GetResult();

            Assert.Equal(200, response.Status);
        }
    }
}