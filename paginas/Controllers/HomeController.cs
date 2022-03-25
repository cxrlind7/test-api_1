using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using paginas.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace paginas.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PersonaClass> listPersonas = new List<PersonaClass>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44351/api/personas"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPersonas = JsonConvert.DeserializeObject<List<PersonaClass>>(apiResponse);
                }
            }
            return View(listPersonas);
        }
    }
}
