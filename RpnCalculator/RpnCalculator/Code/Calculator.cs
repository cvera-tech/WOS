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

        public void Push(Decimal value)
        {
            stack.Push(value);
        }

        public void Drop()
        {
            stack.Pop();
        }

        public string[] GetFourEntries()
        {
            var firstFour = stack.Take(4).ToList();
            var firstFourStrings = new List<string>();
            foreach (var number in firstFour)
            {
                firstFourStrings.Add(number.ToString());
            }
            while (firstFourStrings.Count < 4)
            {
                firstFourStrings.Add(string.Empty);
            }
            return firstFourStrings.ToArray();
        }

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
                operation.Perform(stack);
            }
        }
    }
}