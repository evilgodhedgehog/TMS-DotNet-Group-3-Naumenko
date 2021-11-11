using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Util;
using TMS_DotNet_Group_3_Naumenko.Logic.Managers;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;

namespace TMS_DotNet_Group_3_Naumenko.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isStop = false;
            int mode;

            Console.WriteLine("Operating modes:" +
                    "\n\t1 - get random password (Andrey)" +
                    "\n\t2 - get Holiday on input date in Singapore (Katerina)" +
                    "\n\t3 - get Registered domain names (Dmitry)" +
                    "\n\t4 - ... (Tatyana)\n");

            while (!isStop)
            {
                Console.WriteLine("Input the operating mode:");
                string inputMode = Console.ReadLine();

                if (!int.TryParse(inputMode, out mode) || mode < 1 || mode > 4)
                {
                    Console.WriteLine("Incorrect operating mode!\n");
                }
                else
                {
                    switch (mode)
                    {
                        case 1:
                            {

                            }
                            break;
                        case 2:
                            {

                            }
                            break;
                        case 3:
                            {
                                DomainManager domainManager = new();
                                domainManager.Run();
                            }
                            break;
                        case 4:
                            {

                            }
                            break;
                    }

                    isStop = true;
                }
            }
        }
    }
}