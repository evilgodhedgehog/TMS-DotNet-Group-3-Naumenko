using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Interfaces
{
    public interface IApi
    {
        public string Web { get; set; }
        public List<string> PathSegments { get; set; }
        public List<string> QueryParams { get; set; }

        void Initialize();

        public async Task<dynamic> GetQueryResultAsync()
        {
            await Task.Delay(0);
            return null;
        }

        public void ProcessResult<T>(T result);
    }
}
