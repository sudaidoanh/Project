using Microsoft.AspNetCore.Mvc;
using Project.BackendApi.Models;
using System.Diagnostics;

namespace Project.BackendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok("Home Controller");
        }
    }
}