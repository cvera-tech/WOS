using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum ArgumentType
    {
        String,
        Number,
        DateTime,
        TimeSpan
    }

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
                Console.WriteLine($"argument1: {GetArgumentType(argument1)}");
                Console.WriteLine($"argument2: {GetArgumentType(argument2)}");
                //Console.ReadLine();
            }
        }

        /// <summary>
        /// Prints the prompt message and returns user input if it is a valid string.
        /// </summary>
        /// <param name="message">The prompt to display.</param>
        /// <returns>The valid string.</returns>
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

        /// <summary>
        /// Returns the type of an input argument.
        /// </summary>
        /// <param name="argument">The input string.</param>
        /// <returns>The corresponding ArgumentType.</returns>
        static ArgumentType GetArgumentType(string argument)
        {
            var argType = ArgumentType.String;
            var timeSpan = new TimeSpan();
            var dateTime = new DateTime();
            var intArg = 0;
            if (int.TryParse(argument, out intArg))
            {
                argType = ArgumentType.Number;
            }
            else if (TimeSpan.TryParse(argument, out timeSpan))
            {
                argType = ArgumentType.TimeSpan;
            }
            else if (DateTime.TryParse(argument, out dateTime))
            {
                argType = ArgumentType.DateTime;
            }

            return argType;
        }
    }
}
