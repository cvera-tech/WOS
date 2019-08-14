using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Welcome to the Calculator app!");
            Console.WriteLine("(To quit the app, press CTRL+C)");
            Console.WriteLine("=================================");

            while (true)
            {
                Console.WriteLine();
                //Console.Write("Enter the first argument: ");
                string argument1 = GetArgument("Enter the first argument");
                Console.Write("Enter the operator: ");
                string operatorType = Console.ReadLine();
                //Console.Write("Enter the second Argument: ");
                string argument2 = GetArgument("Enter the second argument");
                Console.WriteLine();
                Console.WriteLine($"Input expression:");
                Console.WriteLine($"{argument1} {operatorType} {argument2}");
                Console.ReadLine();
            }
        }

        static string GetArgument(string message)
        {
            bool validString = false;
            string inputString;
            do
            {
                Console.WriteLine();
                Console.Write($"{message}: ");
                inputString = Console.ReadLine();
                if (string.IsNullOrEmpty(inputString))
                {
                    Console.WriteLine("ERROR: Argument cannot be empty!");
                }
                else
                {
                    validString = true;
                }
            }
            while (!validString);
            return inputString;
        }
    }
}
