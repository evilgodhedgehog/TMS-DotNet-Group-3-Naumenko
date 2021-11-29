using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Interfaces
{
    public interface IApi
    {
        public string Web { get; }
        public List<string> PathSegments { get; }
        public List<string> QueryParams { get; }

        ApiModel Initialize();

        void ProcessResult<T>(T result);
    }
}