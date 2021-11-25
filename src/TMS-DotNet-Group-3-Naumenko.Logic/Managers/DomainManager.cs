using System;
using System.Collections.Generic;
using System.Linq;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;
using Newtonsoft.Json;
using TMS_DotNet_Group_3_Naumenko.Data.Models;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic.Services;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Managers
{
    public class DomainManager
    {
        List<string> pathSegments = new();
        List<string> queryParams = new();

        public async Task RunAsync()
        {
            Console.WriteLine();
            Console.WriteLine("Hello. Welcome to the registered domain names search.\n" +
                              "Input the function number.");
            Console.WriteLine("Select function:\n" +
                              "Search domain - 1;\n" +
                              "Search domain + zone - 2;\n" +
                              "View information about the domain zone - 3.");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("Input a domain name to search");
                        var domain = CheckingEmptyInput();
                        await FormingRequestToServerAsync(domain);
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine("Input a domain name to search");
                        var domain = CheckingEmptyInput();
                        Console.WriteLine("Input a zone name to search");
                        var zone = CheckingEmptyInput();
                        await FormingRequestToServerAsync(domain, zone);
                    }
                    break;
                case "3":
                    {
                        Console.WriteLine("Input a zone name to search");
                        var zone = CheckingEmptyInput();
                        await FormingRequestToServerAsync(zone, pathSegments);
                    }
                    break;
            }
        }

        private async Task FormingRequestToServerAsync(string domain)
        {
            pathSegments.Add("v1");
            pathSegments.Add("domains");
            pathSegments.Add("search");

            queryParams.Add($"domain={domain}");

            await ServerResponseResultAsync();
        }

        private async Task FormingRequestToServerAsync(string domain, string zone)
        {
            pathSegments.Add("v1");
            pathSegments.Add("domains");
            pathSegments.Add("search");

            queryParams.Add($"domain={domain}");
            queryParams.Add($"zone={zone}");

            await ServerResponseResultAsync();
        }

        private async Task FormingRequestToServerAsync(string zone, List<string> pathSegments)
        {
            pathSegments.Add("v1");
            pathSegments.Add("info");
            pathSegments.Add("stat");
            pathSegments.Add($"{zone}");

            await ServerResponseResultAsync();
        }

        private async Task ServerResponseResultAsync()
        {
            DomainAPI web = new("https://api.domainsdb.info", pathSegments, queryParams);

            var getResults = web.GetData().Result;

            var apiModel = new ApiModel
            {
                Web = "https://api.domainsdb.info",
                PathSegments = pathSegments,
                QueryParams = queryParams,
            };

            var url = ApiService<DomainCommonModel>.PrepareRequestAsync(apiModel);
            var result = await ApiService<DomainCommonModel>.GetResultAsync(url);

            Console.WriteLine();

            foreach (var domain in result.domains)
            {
                Console.WriteLine($"{domain.domain} {domain.CNAME} {domain.country}");
            }

            Console.WriteLine();
        }

        private string CheckingEmptyInput()
        {
            var inputValue = Console.ReadLine();

            while (!(inputValue.Length > 0))
            {
                Console.WriteLine("Incorret value. True again...");
            }

            return inputValue;
        }
    }
}