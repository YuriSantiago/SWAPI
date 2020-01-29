using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapcoWebAPI.Factory;
using CapcoWebAPI.Models;
using CapcoWebAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CapcoWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public HomeController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllPeople()
        {
            var allOrderedPeople = await ApiClientFactory.Instance.GetAllPeople();
            return View(allOrderedPeople);
        }

        public async Task<IActionResult> GetPeopleById(string idPeople = "1")
        {
          
            var selectedPeople = await ApiClientFactory.Instance.GetPeopleById(Convert.ToInt32(idPeople));
            return View(selectedPeople);
        }

        public async Task<IActionResult> GetAllHumanPeople()
        {
            
            var allHumans = await ApiClientFactory.Instance.GetAllHumanPeople();
            return View(allHumans);
        }
    }
}
