using System;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic;
using TMS_DotNet_Group_3_Naumenko.Logic.Helpers;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;

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
                Console.WriteLine("Work modes:" +
                    "\n\t1 - get random password (Andrey)" +
                    "\n\t2 - get Holiday on input date in Singapore (Katerina)" +
                    "\n\t3 - get Registered domain names (Dmitry)" +
                    "\n\t4 - ... (Tatyana)");
                int mode = 2;
                while (true)
                {
                    Console.WriteLine("Enter work mode:");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out mode) || mode < 1 || mode > 4)
                    {
                        Console.WriteLine("Incorrect work mode!");
                        continue;
                    }
                    break;
                }
                switch (mode)
                {
                    case 1:
                        {                            
                        }
                        break;

                    case 2:
                        {
                            api = new GetHolidayApi();
                        }
                        break;

                    case 3:
                        {
                        }

                        break;

                    case 4:
                        {
                        }

                        break;
                }

                api.Initialize();
                var result = await api.GetQueryResultAsync();
                api.ProcessResult(result);

                isStop = CommonHelper.AnswerToTheYesNoQuestion("Exit?");
            }
        }
    }
}
