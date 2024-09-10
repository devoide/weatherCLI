using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace WeatherAPI
{
    internal class Program
    {
        static async Task Main(string[] args) //Task is to allow synchronous stuff ykyk, it cannot be void.
        {
            string q = "Regensdorf";

            if (args.Length > 0) 
            {
                q = args[0];
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/forecast.json?key=67b99d2eaabe430cb15195631240309&q=" + q + "&days=1&aqi=no&alerts=no");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            dynamic joResponse = JObject.Parse(responseBody);
            string name = joResponse.location.name;
            string country = joResponse.location.country;
            string tempC = joResponse.current.temp_c.ToString();
            string conditionText = joResponse.current.condition.text;



            Console.WriteLine(name + ", " + country + ": " + tempC + "C, " + conditionText);
        }
    }
}
