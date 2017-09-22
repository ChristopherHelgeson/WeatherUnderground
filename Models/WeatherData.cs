using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WeatherUndergroundAPI.Models
{
    public class WeatherData
    {
        string URLheader = "http://api.wunderground.com/api/";
        string APIkey = "12b8a40c145b360a";
        string param = "/conditions/q/";
        string extension = ".json";

        public JObject CreateObject(string i)
        {
            HttpWebRequest request = WebRequest.CreateHttp(URLheader + APIkey + param + i + extension);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);
            return o;
        }

        public string[] GetLocationInfo(JObject o)
        {
            string[] locationInfo = new string[]
            {
                (o["current_observation"]["display_location"]["full"]).ToString(),
                (o["current_observation"]["observation_location"]["latitude"]).ToString(),
                (o["current_observation"]["observation_location"]["longitude"]).ToString(),
                (o["current_observation"]["observation_location"]["elevation"]).ToString(),
                (o["current_observation"]["observation_time"]).ToString()
            };
            return locationInfo;
        }

        public string[] GetLocationWeather(JObject o)
        {
            string[] locationWeather = new string[]
            {
                (o["current_observation"]["weather"]).ToString(),
                (o["current_observation"]["temperature_string"]).ToString(),
                (o["current_observation"]["dewpoint_string"]).ToString(),
                (o["current_observation"]["relative_humidity"]).ToString(),
                (o["current_observation"]["wind_dir"] + " (" + o["current_observation"]["wind_degrees"] + " degrees) @ " + o["current_observation"]["wind_mph"] + " mph").ToString(),
                (o["current_observation"]["pressure_in"] + "\"").ToString(),
                (o["current_observation"]["icon_url"]).ToString()
             };
            return locationWeather;
        }
    }

    public class Input
    {
        [Required]
        public string Zipcode { get; set; }
    }
}