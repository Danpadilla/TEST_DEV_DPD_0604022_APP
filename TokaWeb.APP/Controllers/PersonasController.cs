using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TokaWeb.APP.Models;

namespace TokaWeb.APP.Controllers
{
    public class PersonasController : Controller
    {
        private readonly  IConfiguration _config;
        public PersonasController(IConfiguration iConfig)
        {
            _config = iConfig;
        }
        // GET: PersonasController
        public ActionResult Index()
        {
             string dbConn2 = _config.GetValue<string>("AppSettings:BaseUrl"); 


            return View();
        }

        // GET: PersonasController/Details/5
        public JsonResult Details(int personId)
        {
            string baseUrl = _config.GetValue<string>("AppSettings:BaseUrl");
            Response r = new Response();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.GetAsync("/api/personas/"+personId.ToString()).Result;
                    DTOsPersonasFisicas personasFisics = new DTOsPersonasFisicas();
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonStringPersonas = response.Content.ReadAsStringAsync().Result;
                        personasFisics = JsonConvert.DeserializeObject<DTOsPersonasFisicas>(jsonStringPersonas);  
                        return Json(personasFisics);
                    }
                    else
                    {
                        r.Status = false;
                        r.Pathredirect = "/";
                        r.ErrorMessage = "Error";
                        return Json(r);
                    }

                }

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Pathredirect = "/";
                r.ErrorMessage = ex.Message;
                return Json(r);

            }
            
        }

         

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(DTOsPersonasFisicas collection)
        {
            string baseUrl = _config.GetValue<string>("AppSettings:BaseUrl");
            Response r = new Response();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync("/api/personas/create", collection).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        r.Status = true;
                        r.Pathredirect = "/";
                        r.Message = "Registro guardaro correctamente";
                    }
                    else {
                        r.Status = false;
                        r.Pathredirect = "/";
                        r.ErrorMessage = "Error";
                    }
                       
                }
                 
            }
            catch(Exception ex)
            {
                r.Status = false;
                r.Pathredirect = "/";
                r.ErrorMessage = ex.Message;
                
            }
            return Json(r);
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(DTOsPersonasFisicas collection)
        {
            string baseUrl = _config.GetValue<string>("AppSettings:BaseUrl");
            Response r = new Response();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PutAsJsonAsync("/api/personas/"+collection.IdPersonaFisica.ToString(), collection).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        r.Status = true;
                        r.Pathredirect = "/";
                        r.Message = "Registro guardaro correctamente";
                    }
                    else
                    {
                        r.Status = false;
                        r.Pathredirect = "/";
                        r.ErrorMessage = "Error";
                    }

                }

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Pathredirect = "/";
                r.ErrorMessage = ex.Message;

            }
            return Json(r);
        }
         

        // POST: PersonasController/Delete/5
        [HttpPost] 
        public JsonResult Delete(int personId)
        {
            string baseUrl = _config.GetValue<string>("AppSettings:BaseUrl");
            Response r = new Response();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.DeleteAsync("/api/personas/"+personId.ToString()).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        r.Status = true;
                        r.Pathredirect = "/";
                        r.Message = "Registro guardaro correctamente";
                    }
                    else
                    {
                        r.Status = false;
                        r.Pathredirect = "/";
                        r.ErrorMessage = "Error";
                    }

                }

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Pathredirect = "/";
                r.ErrorMessage = ex.Message;

            }
            return Json(r);
        }
    }
}
