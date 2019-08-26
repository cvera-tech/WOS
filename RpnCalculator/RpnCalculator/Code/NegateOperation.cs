using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code
{
    public class NegateOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 0)
            {
                var arg1 = stack.Pop();
                var result = -arg1;
                stack.Push(result);
            }
        }
    }
}