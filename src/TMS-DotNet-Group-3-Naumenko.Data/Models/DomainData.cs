using System;
using System.Collections.Generic;

namespace TMS_DotNet_Group_3_Naumenko.Data.Models
{
    public class MX
    {
        public string exchange { get; set; }
        public int priority { get; set; }
    }

    public class Domain
    {
        public string domain { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public string country { get; set; }
        public string isDead { get; set; }
        public IList<string> A { get; set; }
        public IList<string> NS { get; set; }
        public object CNAME { get; set; }
        public IList<MX> MX { get; set; }
        public IList<string> TXT { get; set; }
    }

    public class DomainCommonModel
    {
        public IList<Domain> domains { get; set; }
        public int total { get; set; }
        public string time { get; set; }
        public object next_page { get; set; }
    }
}

