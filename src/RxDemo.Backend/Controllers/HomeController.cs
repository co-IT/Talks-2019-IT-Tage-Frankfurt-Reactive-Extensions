using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RxDemo.Backend.Models;

namespace RxDemo.Backend.Controllers
{
    public class HomeController : Controller
    {
        private static readonly StringBuilder _serverLog = new StringBuilder();
        private static bool _lockClient;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [Route("api/togglestatus")]
        public IActionResult AdminChangedLockStatus(bool lockClient)
        {
            _lockClient = lockClient;

            AddLog($"Client Locked? {lockClient}");

            return Ok();
        }

        [HttpGet]
        [Route("api/status")]
        public bool ShouldLockClient()
        {
            AddLog("Status requested");
            return _lockClient;
        }

        [HttpGet]
        [Route("api/log")]
        public string GetLog()
        {
            return _serverLog.ToString();
        }

        [HttpPost]
        [Route("api/scan")]
        public IActionResult GetGateInDetails(string scan)
        {
            AddLog($"Empfangener Scan: {scan}");

            return scan.Split(new []{','}, StringSplitOptions.RemoveEmptyEntries).Length > 2
                ? new JsonResult(new GateInDetails {Hall = 1, Position = 2, Row = 3})
                : new JsonResult(NoContent()) {StatusCode = 204};
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        private static void AddLog(string message)
        {
            _serverLog.AppendLine($"{DateTime.Now:hh:mm:ss} - {message}");
        }
    }
}