using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class NegateOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 0)
            {
                var arg = stack.Pop();
                var result = -arg;
                stack.Push(result);
            }
        }
    }
}