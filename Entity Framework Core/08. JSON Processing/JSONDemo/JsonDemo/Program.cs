using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;

namespace JsonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            WeatherForecast weather = new WeatherForecast();
            Forecasts forecast = new Forecasts() 
            { 
                AddiotionData = new Tuple<int, string>(123, "Niki"),
                Forecast = new List<WeatherForecast>() 
                { 
                    new WeatherForecast(), 
                    new WeatherForecast(), 
                    new WeatherForecast()
                }
            };

            /* System.Text.Json
            string json = JsonSerializer.Serialize(weather, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            Console.WriteLine(json);
            */


            /* Json.Net
            var json = File.ReadAllText("weather.json");
            JObject jObject = JObject.Parse(json);
            foreach (var item in jObject["connectionStrings"]
                .Where(x => x.ToString().Contains("Server")))
            {
                Console.WriteLine(item);
            }
            */


            // XML-to-JSON

            string xml = @"<?xml version='1.0' standalone='no'?> 
                         <root> 
                            <person id='1'> 
                                <name>Alan</name> 
                                <url>www.google.com</url> 
                            </person> 
                            <person id='2'> 
                                <name>Louis</name> 
                                <url>www.yahoo.com</url> 
                            </person> 
                        </root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(jsonText);

        }
    }

    class WeatherForecast
    {
        public decimal LongNameOfThisDecimalProperty { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public List<int> TemperaturesC { get; set; } = new List<int> {30, 25, 36};

        public string Summary { get; set; } = "Hot summer day";
    }
    
    class Forecasts
    {
        public Tuple<int, string> AddiotionData { get; set; }

        public List<WeatherForecast> Forecast { get; set; }
    }
}
