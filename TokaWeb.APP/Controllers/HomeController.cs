using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TokaWeb.APP.Attributes;
using TokaWeb.APP.Models;

namespace TokaWeb.APP.Controllers
{
    [AuthorizeAtribute]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;


        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _config = iConfig;
        }

        public IActionResult Index()
        {

            string baseUrl = _config.GetValue<string>("AppSettings:BaseUrl");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.
            HttpResponseMessage response = client.GetAsync("/api/personas").Result;  // Blocking call!
            List<DTOsPersonasFisicas> personasFisics = new List<DTOsPersonasFisicas>(); ;
            if (response.IsSuccessStatusCode)
            {
                var jsonStringPersonas = response.Content.ReadAsStringAsync().Result;
                personasFisics = JsonConvert.DeserializeObject<List<DTOsPersonasFisicas>>(jsonStringPersonas);
            } 
            ViewBag.pp = personasFisics;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
