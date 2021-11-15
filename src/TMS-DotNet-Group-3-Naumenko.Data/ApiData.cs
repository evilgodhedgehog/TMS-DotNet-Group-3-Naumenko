using System.Collections.Generic;

namespace TMS_DotNet_Group_3_Naumenko.Data
{
    public class ApiData
    {
        public string Web { get; set; }
        public string PathSegment { get; set; }
        public List<string> QueryParams { get; set; }
        public string Command { get; set; }
    }
}
