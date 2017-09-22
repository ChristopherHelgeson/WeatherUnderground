using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherUndergroundAPI.Models;

namespace WeatherUndergroundAPI.Controllers
{
    // Weather Underground API key: 12b8a40c145b360a
    // Sample: http://api.wunderground.com/api/12b8a40c145b360a/conditions/q/CA/San_Francisco.json

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ByZip(string zip)
        {
            //int zipcode = 45243;

            WeatherData weatherJSON = new WeatherData();

            JObject x = weatherJSON.CreateObjectByZip(zip);

            string[] locationInfo = weatherJSON.GetLocationInfo(x);
            ViewBag.LocationInfo = locationInfo;

            string[] weatherInfo = weatherJSON.GetLocationWeather(x);
            ViewBag.WeatherInfo = weatherInfo;

            return View("Weather");
        }

        public ActionResult ByCityState(string city, string state)
        {
            WeatherData weatherJSON = new WeatherData();

            JObject x = weatherJSON.CreateObjectByCityState(city, state);

            string[] locationInfo = weatherJSON.GetLocationInfo(x);
            ViewBag.LocationInfo = locationInfo;

            string[] weatherInfo = weatherJSON.GetLocationWeather(x);
            ViewBag.WeatherInfo = weatherInfo;

            return View("Weather");
        }
    }
}