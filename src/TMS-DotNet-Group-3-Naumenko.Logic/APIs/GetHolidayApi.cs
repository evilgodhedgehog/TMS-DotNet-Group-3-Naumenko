using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Text;
using TMS_DotNet_Group_3_Naumenko.Data;
using TMS_DotNet_Group_3_Naumenko.Logic.Helpers;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;
using System.Linq;
using System.Reflection;

namespace TMS_DotNet_Group_3_Naumenko.Logic
{
    public class HolidayInfo
    {
        /* Response contains following fields:
            * "name": "Chinese New Year's Day",   
            * "name_local": "...",  
            * "language": "...",  
            * "description": "Part of the long weekend",  
            * "country": "SG",  
            * "location": "Singapore",
            * "type": "public_holiday",  
            * "date": "1/25/2020",  
            * "date_year": "2020",  
            * "date_month":"1",  
            * "date_day": "25",  
            * "week_day": "Saturday" 
        * */
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
    }

    public class GetHolidayApi : IApi
    {
        public string Web { get; set; }
        public List<string> PathSegments { get; set; }
        public List<string> QueryParams { get; set; }

        public void Initialize()
        {
            Web = "https://holidays.abstractapi.com";
            PathSegments = new List<string> {"v1"};
            QueryParams = HolidayHelper.GetQueryParams();
        }

        public async Task<dynamic> GetQueryResultAsync()
        {
            try
            {
                return await Web.AppendPathSegments(PathSegments.ToArray())
                    .SetQueryParams(QueryParams.ToArray())
                    .GetJsonAsync<List<HolidayInfo>>();
            }
            catch (FlurlHttpException)
            {
                throw new Exception("Incorrect API request! Please, check input date.");
            }
        }

        public void ProcessResult<T>(T apiResponse)
        {
            var holidayFromApi = apiResponse as List<HolidayInfo>;
            if (holidayFromApi is {Count: 0})
            {
                Console.WriteLine("No Holidays in this day");
                return;
            }

            Console.WriteLine("\n****************************************");
            Console.WriteLine($"Name of Holiday: {holidayFromApi[0].Name}");
            Console.WriteLine($"Location: {holidayFromApi[0].Location}");
            Console.WriteLine($"Date: {holidayFromApi[0].Date}");
            Console.WriteLine("****************************************");
        }
    }
}