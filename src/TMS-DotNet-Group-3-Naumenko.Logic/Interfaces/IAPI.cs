using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Interfaces
{
    public interface IAPI
    {
        public string Web { get; set; }
        public List<string> PathSegments { get; set; }
        public List<string> QueryParams { get; set; }

        public Task<dynamic> GetData();
    }
}