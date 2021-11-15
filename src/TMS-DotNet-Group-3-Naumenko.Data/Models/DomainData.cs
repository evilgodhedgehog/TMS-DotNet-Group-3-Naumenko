using System;
using System.Collections.Generic;

namespace TMS_DotNet_Group_3_Naumenko.Data.Models
{
    public class Domain
    {
        public string domain { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }
        public string Country { get; set; }
        public string IsDead { get; set; }
        public List<string> A { get; set; }
        public List<string> NS { get; set; }
        public object CNAME { get; set; }
        public object MX { get; set; }
        public object TXT { get; set; }
    }

    public class Response
    {
        public List<Domain> Domains { get; set; }
        public int Total { get; set; }
        public string Time { get; set; }
        public object Next_page { get; set; }
    }
}

