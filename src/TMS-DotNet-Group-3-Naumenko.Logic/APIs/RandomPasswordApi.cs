using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic.Helpers;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;


namespace TMS_DotNet_Group_3_Naumenko.Logic.APIs
{
    public class RandomPasswordApi : IApi
    {
        public string Web { get; set; }
        public List<string> PathSegments { get; set; }
        public List<string> QueryParams { get; set; }

        public void Initialize()
        {
            Web = "https://passwordinator.herokuapp.com";
            PathSegments = new List<string>() { "generate" };
            QueryParams = RandPassHelper.GetQueryParams();
        }
        public async Task<dynamic> GetQueryResultAsync()
        {
            var result = await Web
                .AppendPathSegments(PathSegments.ToArray())
                .SetQueryParams(QueryParams.ToArray())
                .GetJsonAsync();
            return result.data;
        }

        public void ProcessResult<T>(T result)
        {
            Console.Write($"Random password: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{result}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
