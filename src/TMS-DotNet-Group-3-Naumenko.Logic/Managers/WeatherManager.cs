using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using TMS_DotNet_Group_3_Naumenko.Data.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Managers
{
    public class WeatherManager
    {
        public void CreateResponce()
        {
            string originweb = "http://api.openweathermap.org/data/2.5/weather?q=";
            Console.WriteLine("Enter name of city ");
            string responce = Console.ReadLine();
            string webend = "&units=metric&appid=dc380e4cabfc59378d055e5cdb40801a";
            string web = originweb + responce + webend;
            WeitherForecast(web);
        }

        public void WeitherForecast(string web)
        {
            double farengeith;
            double kelvin;
            WebResponse response = null;
            try
            {
                WebRequest request = WebRequest.Create(web);
                response = request.GetResponse();
                Stream newStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(newStream);
                var readjson = reader.ReadToEnd();

                WetherMenu wetther = JsonConvert.DeserializeObject<WetherMenu>(readjson);
                farengeith = Math.Round((wetther.main.Temp * 9 / 5) + 32, 2);
                kelvin = Math.Round(wetther.main.Temp + 273.15, 2);
                foreach (var elem in wetther.weather)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(($"{"Weather",15}").ToUpper() +
                        $"\n {DateTime.Now.ToString("dddd, dd MMMM yyyy")}\n" +
                        "{0,14}", (wetther.Name.ToUpper()));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n { elem.Description.ToUpper()}" +
                        $"\n\n Temperature: { wetther.main.Temp}°C [{farengeith}°F] [{kelvin}K]" +
                        $"\n\n Humidity: {wetther.main.Humidity} %" +
                        $"\n\n Wind speed: {wetther.wind.Speed} km/h" +
                        $"\n\n Feels like: {wetther.main.Feels_like}°C");

                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" City has been found.\n Try again.\n Enter name of city in English");
                Console.ResetColor();
                CreateResponce();
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
        }

        public void AdvertisementNews()
        {
            WebRequest request = WebRequest.Create("https://newsapi.org/v2/everything?domains=bbc.com&q=minsk&language=en&apiKey=3fcb1ccc7c344009acfca65a838ec527");
            using (WebResponse response = request.GetResponse())
            using (Stream newStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(newStream))
            {
                var r1 = reader.ReadToEnd();

                NewsMenu newss = JsonConvert.DeserializeObject<NewsMenu>(r1);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(("Read the latest news from your region").ToUpper());
                Console.WriteLine();
                foreach (var elem in newss.Articles)

                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"·{elem.Title}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("↓ more details on the link ↓ ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(elem.Url);
                    Console.ResetColor();
                    Console.WriteLine("----------------------------------------");
                }
            }
        }
    }
}

