using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Managers
{
    public class DomainManager
    {
        List<string> pathSegments = new();
        List<string> queryParams = new();

        public void Run()
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
                        FormingRequestTOServer(domain, pathSegments, queryParams);
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine("Input a domain name to search");
                        var domain = CheckingEmptyInput();
                        Console.WriteLine("Input a zone name to search");
                        var zone = CheckingEmptyInput();
                        FormingRequestTOServer(domain, zone, pathSegments, queryParams);
                    }
                    break;
                case "3":
                    {
                        Console.WriteLine("Input a zone name to search");
                        var zone = CheckingEmptyInput();
                        FormingRequestTOServer(zone, pathSegments);
                    }
                    break;
            }
        }

        private void FormingRequestTOServer(string domain, List<string> pathSegments, List<string> queryParams)
        {
            pathSegments.Add("v1");
            pathSegments.Add("domains");
            pathSegments.Add("search");

            queryParams.Add($"domain={domain}");

            ServerResponseResult(pathSegments, queryParams);
        }

        private void FormingRequestTOServer(string domain, string zone, List<string> pathSegments, List<string> queryParams)
        {
            pathSegments.Add("v1");
            pathSegments.Add("domains");
            pathSegments.Add("search");

            queryParams.Add($"domain={domain}");
            queryParams.Add($"zone={zone}");

            ServerResponseResult(pathSegments, queryParams);
        }

        private void FormingRequestTOServer(string zone, List<string> pathSegments)
        {
            pathSegments.Add("v1");
            pathSegments.Add("info");
            pathSegments.Add("stat");
            pathSegments.Add($"{zone}");

            ServerResponseResult(pathSegments, queryParams);
        }

        private void ServerResponseResult(List<string> pathSegments, List<string> queryParams)
        {
            DomainAPI domain = new("https://api.domainsdb.info", pathSegments, queryParams);

            var getResults = domain.GetData().Result;

            foreach (var result in getResults)
            {
                foreach (var values in result.Value)
                {
                    Console.WriteLine();

                    foreach (var element in values)
                    {
                        Console.WriteLine(element);
                    }
                }
            }

            //Console.WriteLine(getResults);
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