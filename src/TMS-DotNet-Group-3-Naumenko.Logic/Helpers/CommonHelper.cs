using System;
namespace TMS_DotNet_Group_3_Naumenko.Logic.Helpers
{
    public class CommonHelper
    {
        public static bool AnswerToTheYesNoQuestion(string question)
        {
            while (true)
            {
                Console.Write($"{question}\nEnter y/n:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Incorrect answer!");
                        break;
                }
            }
        }
    }
}
