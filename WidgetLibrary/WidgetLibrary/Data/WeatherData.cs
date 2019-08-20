using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WidgetLibrary.Data
{
    /// <summary>
    /// Static class that provides weather data.
    /// </summary>
    public static class WeatherData
    {
        /// <summary>
        /// Converts JSON data into a dictionary.
        /// </summary>
        /// <param name="jsonString">The JSON data as a string.</param>
        /// <returns>A dictionary.</returns>
        private static Dictionary<string, string> GetDictionaryFromJson(string jsonString)
        {
            var data = new Dictionary<string, string>();

            var json = JObject.Parse(jsonString);

            // See https://openweathermap.org/weather-data
            // for a list of the available response properties
            // and associated units.
            data.Add("Location Name", (string)json["name"]);
            data.Add("Temperature", (string)json["main"]["temp"]);
            data.Add("Temperature Min", (string)json["main"]["temp_min"]);
            data.Add("Temperature Max", (string)json["main"]["temp_max"]);
            data.Add("Pressure", (string)json["main"]["pressure"]);
            data.Add("Humidity", (string)json["main"]["humidity"]);
            data.Add("Wind Speed", (string)json["wind"]["speed"]);

            return data;
        }

        /// <summary>
        /// Retrieves the OpenWeatherMap API key from the app settings.
        /// </summary>
        /// <returns>The API key as a string.</returns>
        private static string GetApiKeyFromConfig()
        {
            string apiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ApplicationException("Missing 'OpenWeatherApiKey' app settings key.");
            }

            return apiKey;
        }

        /// <summary>
        /// Retrieves the weather for the provide zip code
        /// using the OpenWeatherMap API
        /// (https://openweathermap.org/weather-data).
        /// Note: If an error occurs while retrieving data from
        /// the API, this method will write the error to the
        /// output window and return `null`.
        /// </summary>
        /// <param name="zip">The US zip code to return weather information for.</param>
        /// <returns>A string-string dictionary containing the weather information.</returns>
        public static Dictionary<string, string> CallApi(string zip)
        {
            Dictionary<string, string> data = null;

            string apiKey = GetApiKeyFromConfig();

            try
            {
                // NOTE: Using WebClient here instead of HttpClient
                // in order to avoid an asynchronous method.
                var client = new WebClient();
                string response = client.DownloadString(
                    $"http://api.openweathermap.org/data/2.5/weather?zip={zip},us&units=imperial&appid={apiKey}");
                data = GetDictionaryFromJson(response);
            }
            catch (WebException ex)
            {
                Debug.WriteLine($"Error calling API: {ex}");
            }

            return data;
        }
    }
}