using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Data.Models;
using TMS_DotNet_Group_3_Naumenko.Logic.Helpers;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic.APIs
{
    public class RandomPasswordApi : IApi
    {
        public string Web { get; private set; }

        public List<string> PathSegments { get; private set; }

        public List<string> QueryParams { get; private set; }

        public ApiModel Initialize()
        {
            Web = "https://passwordinator.herokuapp.com";
            PathSegments = new List<string>() { "generate" };
            QueryParams = RandPassHelper.GetQueryParams();

            return new ApiModel
            {
                Web = Web,
                PathSegments = PathSegments,
                QueryParams = QueryParams,
            };
        }

        public void ProcessResult<T>(T result)
        {
            var passwordResult = result as PasswordModel;

            Console.Write($"Random password: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{passwordResult.data}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
