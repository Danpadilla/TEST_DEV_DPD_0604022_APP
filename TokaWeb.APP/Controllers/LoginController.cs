using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks; 
using TokaWeb.APP.Models;

namespace TokaWeb.APP.Controllers
{
    public class LoginController : Controller
    {

        // GET: LoginController
        public ActionResult Index()
        {
             HttpContext.Response.Cookies.Delete("user-login");
            string token = HttpContext.Request.Cookies["user-login"];
            if (!string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(); 
            }

        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(Login userRequest)
        {
             
            string baseUrl = "https://api.toka.com.mx";
            Response r = new Response();
            try
            { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync("/candidato/api/login/authenticate", userRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Login loginWithData = new Login();
                        var jsonStringPersonas = response.Content.ReadAsStringAsync().Result;
                        loginWithData = JsonConvert.DeserializeObject<Login>(jsonStringPersonas);
                        userRequest.Token = loginWithData.Data;
                        //Declaramos una cookie
                        HttpContext.Response.Cookies.Append("user-login",
                            userRequest.Token, new CookieOptions()
                            {
                                Expires = DateTime.Now.AddDays(7),
                                IsEssential = true
                            });
                        return Json(userRequest);

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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
