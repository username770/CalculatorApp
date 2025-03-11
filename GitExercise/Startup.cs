using System;
using System.ComponentModel;

namespace GitExercise
{
    public class Startup
    {
        public static void Main()
        {

            bool Auth = CheckCredentials();

            if(!Auth)
            {
                Console.WriteLine("Access Denied.");
                Console.ReadKey(true);
                return;
            }

            while (true)
            {
                Console.WriteLine("Console Calculator App");
                Console.WriteLine(new string('-', 15));

                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                Console.WriteLine("Choose one from the listed options:");
                foreach (string option in OptionsManager.OptionsList)
                {
                    Console.WriteLine($"\t{option}");
                }

                Console.Write("Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":
                        OptionsManager.Add(a, b);
                        break;
                    case "s":
                        OptionsManager.Subtract(a, b);
                        break;
                    case "m":
                        OptionsManager.Multiply(a, b);
                        break;
                    case "d":
                        OptionsManager.Divide(a, b);
                        break;
                    case "dr":
                        OptionsManager.DivideRemainder(a, b);
                        break;
                    case "sabs":
                        OptionsManager.SubtractAbs(a, b);
                        break;
                    case "ex":
                        Console.WriteLine("Bye");
                        Console.ReadKey(true);
                        return;
                }

                Console.WriteLine("Pres any key to close the app...");
                Console.ReadKey(true);
            }
        }
        
        private static bool CheckCredentials()
        {
            string pass = Console.ReadLine();
            Console.Clear();

            return pass == Password;
        }

        private const string Password = "abcd1234";
    }
}
