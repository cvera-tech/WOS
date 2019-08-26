using RpnCalculator.Code.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code
{
    [Serializable]
    public class Calculator
    {
        private Stack<Decimal> stack { get; set; }

        public Calculator()
        {
            stack = new Stack<decimal>();
        }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="value"></param>
        public void Push(decimal value)
        {
            stack.Push(value);
        }

        /// <summary>
        /// Removes the first element in the stack.
        /// </summary>
        public void Drop()
        {
            stack.Pop();
        }

        /// <summary>
        /// Returns the first four entries of the stack as an array of strings.
        /// </summary>
        /// <returns>The first four numbers on the stack.</returns>
        public string[] GetFourEntries()
        {
            var firstFour = stack.Take(4).ToList();
            var firstFourStrings = new List<string>();
            foreach (var number in firstFour)
            {
                firstFourStrings.Add(number.ToString());
            }
            // Make sure there are always four strings
            while (firstFourStrings.Count < 4)
            {
                firstFourStrings.Add(string.Empty);
            }
            return firstFourStrings.ToArray();
        }

        /// <summary>
        /// Calls the IOperation that corresponds to the input OperationType
        /// </summary>
        /// <param name="operationType">The operation to perform.</param>
        public void PerformOperation(OperationType operationType)
        {
            IOperation operation = null;
            switch (operationType)
            {
                case OperationType.Add:
                    operation = new AddOperation();
                    break;
                case OperationType.Minus:
                    operation = new MinusOperation();
                    break;
                case OperationType.Multiply:
                    operation = new MultiplyOperation();
                    break;
                case OperationType.Divide:
                    operation = new DivideOperation();
                    break;
                case OperationType.Negate:
                    operation = new NegateOperation();
                    break;
                case OperationType.SquareRoot:
                    operation = new SquareRootOperation();
                    break;
                case OperationType.Exponential:
                    operation = new ExponentialOperation();
                    break;
                case OperationType.Power:
                    operation = new PowerOperation();
                    break;
                case OperationType.Reciprocal:
                    operation = new ReciprocalOperation();
                    break;
                case OperationType.Sine:
                    operation = new SineOperation();
                    break;
                case OperationType.Cosine:
                    operation = new CosineOperation();
                    break;
                case OperationType.Clear:
                    operation = new ClearOperation();
                    break;
                case OperationType.Swap:
                    operation = new SwapOperation();
                    break;
                case OperationType.Rotate:
                    operation = new RotateOperation();
                    break;
            }
            if (operation != null)
            {
                /*
                Exception handling is done within each class that implements IOperation.
                Refactoring to multiple operation types (e.g. BinaryOperation,
                UnaryOperation, and StackOperation) can make the code DRYer as each type
                can use similar exception handling.
                */
                operation.Perform(stack);
            }
        }
    }
}