using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Text;
using TMS_DotNet_Group_3_Naumenko.Logic.Helpers;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;
using System.Linq;
using System.Reflection;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;
using TMS_DotNet_Group_3_Naumenko.Data.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic
{
    public class GetHolidayApi : IApi
    {
        public string Web { get; private set; }

        public List<string> PathSegments { get; private set; }

        public List<string> QueryParams { get; private set; }

        public ApiModel Initialize()
        {
            Web = "https://holidays.abstractapi.com";
            PathSegments = new List<string> {"v1"};
            QueryParams = HolidayHelper.GetQueryParams();

            return new ApiModel
            {
                Web = Web,
                PathSegments = PathSegments,
                QueryParams = QueryParams,
            };
        }

        public void ProcessResult<T>(T apiResponse)
        {
            var holidayFromApi = apiResponse as List<HolidayModel>;
            if (!holidayFromApi.Any())
            {
                Console.WriteLine("No Holidays in this day");
                return;
            }

            Console.WriteLine("\n****************************************");
            Console.WriteLine($"Name of Holiday: {holidayFromApi[0].name}");
            Console.WriteLine($"Location: {holidayFromApi[0].location}");
            Console.WriteLine($"Date: {holidayFromApi[0].date}");
            Console.WriteLine("****************************************");
        }
    }
}