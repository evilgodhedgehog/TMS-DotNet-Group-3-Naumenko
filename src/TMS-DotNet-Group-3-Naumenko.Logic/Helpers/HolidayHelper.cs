using System;
using System.Collections.Generic;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Helpers
{
    public class HolidayHelper
    {
        const string APIKEY = "02a268dfcac1410ebd5db6c16ba36cb6";

        public static List<string> GetQueryParams()
        {
            List<string> queryParams = new();
            queryParams.Add("api_key=" + APIKEY);
            queryParams.Add("country=SG");

            Console.WriteLine("\nInput Year");
            string year = Console.ReadLine();
            queryParams.Add("year=" + year);

            Console.WriteLine("Input Month");
            string month = Console.ReadLine();
            queryParams.Add("month=" + month);

            Console.WriteLine("Input Day");
            string day = Console.ReadLine();
            queryParams.Add("day=" + day);

            return queryParams;
        }
    }
}
