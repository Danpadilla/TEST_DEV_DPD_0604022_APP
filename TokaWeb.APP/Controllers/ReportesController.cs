using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TokaWeb.APP.Attributes;
using TokaWeb.APP.Models;

namespace TokaWeb.APP.Controllers
{
    [AuthorizeAtribute]
    public class ReportesController : Controller
    {
        private readonly IConfiguration _config;

        public ReportesController(IConfiguration iConfig)
        {
            _config = iConfig;

        }
        // GET: ReportesController
        public ActionResult Index([FromQuery (Name = "pageNumber")] int pageNumber = 1)
        {
            string baseUrl = "https://api.toka.com.mx";
            Response r = new Response();
            Clientes clientes = new Clientes();

            try
            {
                string token = HttpContext.Request.Cookies["user-login"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var response = client.GetAsync("/candidato/api/customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonStringPersonas = response.Content.ReadAsStringAsync().Result;
                        clientes = JsonConvert.DeserializeObject<Clientes>(jsonStringPersonas);
                       

                    }
                    else
                    {
                        //Redireccionamos por el token no existe
                        return RedirectToAction("Index", "Login");
                    }

                }

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Pathredirect = "/";
                r.ErrorMessage = ex.Message;

            }
            // PAGINADO
            //Jajaj por tiempo DataTables
           // IList<Clientes> clientesPage = GetPage(clientes, pageNumber, 50);

            ViewBag.Clientes = clientes.Data;
            return View();
        }
        public IList<Clientes> GetPage(IList<Clientes> list, int page, int pageSize)
        {
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }
        // GET: ReportesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
