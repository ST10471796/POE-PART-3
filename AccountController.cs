using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using RaceDay.Web.Models;

namespace RaceDay.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var client = _httpClientFactory.CreateClient("RaceDayApi");
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic? result = JsonConvert.DeserializeObject(responseString);

                HttpContext.Session.SetString("JWToken", (string)result.Token);
                HttpContext.Session.SetString("UserRole", (string)result.Role);

                return RedirectToAction("Index", "Events");
            }

            ViewBag.Error = "Invalid email or password.";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}