using System.Collections.Generic;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Models
{
    public class ApiModel
    {
        public string Web { get; set; }

        public List<string> PathSegments { get; set; }

        public List<string> QueryParams { get; set; }
    }
}
