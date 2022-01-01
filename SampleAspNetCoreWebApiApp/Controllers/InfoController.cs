using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleAspNetCoreWebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<InfoController> _logger;

        public InfoController(ILogger<InfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Host name: " + Dns.GetHostName());
            sb.AppendLine($"Host: {Request.Host.Host}");
            sb.AppendLine($"Port: {Request.Host.Port}");
            var connectionInfo = Request.HttpContext.Connection;
            sb.AppendLine($"RemoteIpAddress: {connectionInfo.RemoteIpAddress.MapToIPv4()}");
            sb.AppendLine($"RemotePort: {connectionInfo.RemotePort}");
            sb.AppendLine($"LocalIpAddress: {connectionInfo.LocalIpAddress.MapToIPv4()}");
            sb.AppendLine($"LocalPort: {connectionInfo.LocalPort}");
            foreach(var header in Request.Headers)
            {
                sb.AppendLine($"{header.Key}:{header.Value}");
            }
            return Content(sb.ToString());
        }
    }
}
