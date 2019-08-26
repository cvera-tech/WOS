using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class SwapOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 1)
            {
                var arg2 = stack.Pop();
                var arg1 = stack.Pop();
                stack.Push(arg2);
                stack.Push(arg1);
            }
        }
    }
}