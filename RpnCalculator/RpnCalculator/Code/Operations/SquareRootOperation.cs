using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class SquareRootOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 0)
            {
                var arg = stack.Pop();
                var result = Math.Sqrt(decimal.ToDouble(arg));
                stack.Push((decimal)result);
            }
        }
    }
}