using System.Collections.Generic;

namespace TMS_DotNet_Group_3_Naumenko.Data
{
    public class WetherMenu
    {
        public Main main { get; set; }
        public string Name { get; set; }
        public List<Weather> weather { get; set; }
        public Wind wind { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Humidity { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string Description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }

    public class NewsMenu
    {
        //public string Status { get; set; }
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }
    }

    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}