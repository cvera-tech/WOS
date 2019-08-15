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

    enum OperatorType
    {
        Unknown,
        Addition,
        Subtraction,
        Multiplication,
        Division
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
                string argument1 = GetArgument("Enter the first argument");
                OperatorType operatorType = GetOperatorType();
                string argument2 = GetArgument("Enter the second argument");

                var argument1Type = GetArgumentType(argument1);
                var argument2Type = GetArgumentType(argument2);
                bool validExpression = false;

                if (operatorType != OperatorType.Unknown)
                {
                    // Number operator number
                    if (argument1Type == ArgumentType.Number && argument2Type == ArgumentType.Number)
                    {
                        validExpression = true;
                        double number1 = double.Parse(argument1);
                        double number2 = double.Parse(argument2);
                        double result = 0.0;

                        switch (operatorType)
                        {
                            case OperatorType.Addition:
                                result = number1 + number2;
                                break;
                            case OperatorType.Subtraction:
                                result = number1 - number2;
                                break;
                            case OperatorType.Multiplication:
                                result = number1 * number2;
                                break;
                            case OperatorType.Division:
                                // Doubles can divide by zero
                                result = number1 / number2;
                                break;
                            default:
                                Console.WriteLine("What in the world happened?");
                                break;
                        }
                        Console.WriteLine($"Result = {result}");

                    }
                    else if (argument1Type == ArgumentType.String)
                    {
                        if (argument2Type == ArgumentType.String)
                        {
                            // String + String
                            if (operatorType == OperatorType.Addition)
                            {
                                validExpression = true;
                                string result = argument1 + argument2;
                                Console.WriteLine($"Result = {result}");
                            }
                            // String - String
                            else if (operatorType == OperatorType.Subtraction)
                            {
                                validExpression = true;
                                var result = new StringBuilder();
                                var arg1CharArray = argument1.ToCharArray();
                                foreach (char arg1Char in arg1CharArray)
                                {
                                    if (!argument2.Contains(arg1Char))
                                    {
                                        result.Append(arg1Char);
                                    }
                                }
                                Console.WriteLine($"Result = {result}");
                            }
                        }
                        // String * Number
                        else if (argument2Type == ArgumentType.Number && operatorType == OperatorType.Multiplication)
                        {
                            validExpression = true;
                            var result = new StringBuilder();

                            // Do not support partial duplication of strings
                            var times = (int)double.Parse(argument2);

                            for (int counter = 0; counter < times; counter++)
                            {
                                result.Append(argument1);
                            }
                            Console.WriteLine($"Result = {result}");
                        }
                    }
                    else if (argument1Type == ArgumentType.DateTime)
                    {
                        // DateTime - DateTime
                        if (argument2Type == ArgumentType.DateTime && operatorType == OperatorType.Subtraction)
                        {
                            validExpression = true;
                            var dateTime1 = DateTime.Parse(argument1);
                            var dateTime2 = DateTime.Parse(argument2);
                            var result = dateTime1 - dateTime2;
                            Console.WriteLine($"Result = {result}");
                        }
                        else if (argument2Type == ArgumentType.TimeSpan)
                        {
                            var dateTime = DateTime.Parse(argument1);
                            var timeSpan = TimeSpan.Parse(argument2);
                            // DateTime + TimeSpan
                            if (operatorType == OperatorType.Addition)
                            {
                                validExpression = true;
                                var result = dateTime + timeSpan;
                                Console.WriteLine($"Result = {result}");
                            }
                            // DateTime - TimeSpan
                            else if (operatorType == OperatorType.Subtraction)
                            {
                                validExpression = true;
                                var result = dateTime - timeSpan;
                                Console.WriteLine($"Result = {result}");
                            }
                        }
                    }
                }

                if (!validExpression)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Invalid expression");
                    Console.WriteLine("=================================");
                    Console.WriteLine("These operations are supported:");
                    Console.WriteLine("=> Arithmetic operations on Numbers");
                    Console.WriteLine("=> String + String");
                    Console.WriteLine("=> String - String");
                    Console.WriteLine("=> DateTime - DateTime");
                    Console.WriteLine("=> DateTime + TimeSpan");
                    Console.WriteLine("=> DateTime - TimeSpan");
                    Console.WriteLine("=> String * Number");
                    Console.WriteLine("=================================");
                }

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
            var number = 0.0;

            // TimeSpan.Parse accepts doubles, so we try to parse as a double first
            if (double.TryParse(argument, out number))
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

        /// <summary>
        /// Prompts the user to input an operator and returns the corresponing OperatorType.
        /// </summary>
        /// <returns>The OperatorType.</returns>
        static OperatorType GetOperatorType()
        {
            var operatorType = OperatorType.Unknown;
            bool validChar = false;
            char inputChar;
            do
            {
                Console.WriteLine();
                Console.Write("Enter the operator: ");
                inputChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (inputChar)
                {
                    case '+':
                        operatorType = OperatorType.Addition;
                        validChar = true;
                        break;
                    case '-':
                        operatorType = OperatorType.Subtraction;
                        validChar = true;
                        break;
                    case '*':
                        operatorType = OperatorType.Multiplication;
                        validChar = true;
                        break;
                    case '/':
                        operatorType = OperatorType.Division;
                        validChar = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Operator invalid! Input one of the following characters: + - * /");
                        break;
                }
            }
            while (!validChar);

            return operatorType;
        }
    }
}
