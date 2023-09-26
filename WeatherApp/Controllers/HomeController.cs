using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherApiService weatherApiService;

        public HomeController(IWeatherApiService weatherApiService)
        {
            this.weatherApiService = weatherApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string title)
        {
            WeatherApiResponse result = null;

            try
            {
                result = await weatherApiService.SearchByTitleAsync(title);
            }
            catch (Exception ex)
            {
                ViewBag.errorMessages = ex.Message;
            }

            ViewBag.searchWeather = title;
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
