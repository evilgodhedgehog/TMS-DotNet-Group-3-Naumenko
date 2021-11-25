
using System;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic;
using TMS_DotNet_Group_3_Naumenko.Logic.Helpers;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;
using TMS_DotNet_Group_3_Naumenko.Logic.APIs;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic.Managers;
using TMS_DotNet_Group_3_Naumenko.Data.Models;
using TMS_DotNet_Group_3_Naumenko.Logic.Services;

namespace TMS_DotNet_Group_3_Naumenko.UI
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            bool isStop = false;
            IApi api = null;

            while (!isStop)
            {
                Console.WriteLine("Operating modes:" +
                    "\n\t1 - get random password (Andrey)" +
                    "\n\t2 - get Holiday on input date in Singapore (Katerina)" +
                    "\n\t3 - get Registered domain names (Dmitry)" +
                    "\n\t4 - get Weather and News the city (Tatyana)\n");
                int mode;
                while (true)
                {
                    Console.WriteLine("Enter operating mode:");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out mode) || mode < 1 || mode > 4)
                    {
                        Console.WriteLine("Incorrect operating mode!");
                        continue;
                    }
                    break;
                }
                switch (mode)
                {
                    case 1:
                        {
                            api = new RandomPasswordApi();
                            var apiModel = api.Initialize();
                            var url = ApiService<PasswordModel>.PrepareRequestAsync(apiModel);
                            var result = await ApiService<PasswordModel>.GetResultAsync(url);
                            api.ProcessResult(result);
                        }
                        break;
                    case 2:
                        {
                          api = new GetHolidayApi();
                          
                          try
                          {
                                var apiModel = api.Initialize();
                                var url = ApiService<HolidayModel>.PrepareRequestAsync(apiModel);
                                var result = await ApiService<HolidayModel>.GetResultsAsync(url);
                                api.ProcessResult(result);
                          }
                          catch (Exception exception)
                          {
                             Console.WriteLine(exception.Message);
                          }
                        }
                        break;
                    case 3:
                        {
                            DomainManager domainManager = new();
                            await domainManager.RunAsync();
                        }
                        break;
                    case 4:
                        {
                          WeatherManager start = new();
                          start.CreateResponce();
                          start.AdvertisementNews();
                        }
                        break;                        
                }
                
                isStop = CommonHelper.AnswerToTheYesNoQuestion("Exit?");
            }
        }
    }
}