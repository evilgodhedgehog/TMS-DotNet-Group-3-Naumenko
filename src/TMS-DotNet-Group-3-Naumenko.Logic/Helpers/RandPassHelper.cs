using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Helpers
{
    public class RandPassHelper
    {
        public static List<string> GetQueryParams()
        {
            List<string> queryParams = new List<string>();
            Console.WriteLine("Standart parameters for password: use smallcase alphabets, length = 8");
            if (CommonHelper.AnswerToTheYesNoQuestion("Use numbers?") == true)
            {
                queryParams.Add("num=true");
            }
            if (CommonHelper.AnswerToTheYesNoQuestion("Use special character?") == true)
            {
                queryParams.Add("char=true");
            }
            if (CommonHelper.AnswerToTheYesNoQuestion("Use uppercase alphabets?") == true)
            {
                queryParams.Add("caps=true");
            }
            if (CommonHelper.AnswerToTheYesNoQuestion("Set length?") == true)
            {
                while (true)
                {
                    Console.WriteLine("Enter length:");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out int length) && length > 0)
                    {
                        queryParams.Add($"len={length}");
                        break;
                    }
                    Console.WriteLine("Incorrect length!");
                }
            }
            return queryParams;
        }
    }
}
