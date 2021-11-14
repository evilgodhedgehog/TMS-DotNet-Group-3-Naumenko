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

namespace TMS_DotNet_Group_3_Naumenko.Logic
{
    public class MyItem
    {
        public string name { get; set; }
        public string location { get; set; }
        public string date { get; set; }
    }

    public class GetHolidayApi : IApi
    {

        public string Web { get; set; }
        public List<string> PathSegments { get; set; }
        public List<string> QueryParams { get; set; }

        public void Initialize()
        {
            Web = "https://holidays.abstractapi.com";
            PathSegments = new List<string>() { "v1" };
            QueryParams = HolidayHelper.GetQueryParams();
        }

        public async Task<dynamic> GetQueryResultAsync()
        {
            try
            {
                var url = Web.AppendPathSegments(PathSegments.ToArray());
                var getRequest = url.SetQueryParams(QueryParams.ToArray());
                var result = await getRequest.GetJsonAsync<List<MyItem>>();

                Responce(result);
                return result;
            }
            catch (FlurlHttpException)
            {
                Console.WriteLine("Input correct date! Not found this addres in API");
                Initialize();
                await GetQueryResultAsync();
            }

            return 0;
        }

        public void ProcessResult<T>(T result)

        {

        }

        public void Responce(List<MyItem> response)
        {
            /*
            * "name": "Chinese New Year's Day",   
            * "name_local": "",  
            * "language": "",  
            * "description": "Part of the long weekend",  
            * "country": "SG",  
            * "location": "",
            * "type": "public_holiday",  
            * "date": "1/25/2020",  
            * "date_year": "2020",  
            * "date_month":"1",  
            * "date_day": "25",  
            * "week_day": "Saturday" 
            * */
            if (response.Count() != 0)
            {
                Console.WriteLine("\n****************************************");
                Console.WriteLine($"Name of Holiday: {response[0].name}");
                Console.WriteLine($"Country: {response[0].location}");
                Console.WriteLine($"Date: {response[0].date}");
                Console.WriteLine("****************************************");
            }
            else
            {
                Console.WriteLine("No Holidays in this day");
            }

        }
    }
}
