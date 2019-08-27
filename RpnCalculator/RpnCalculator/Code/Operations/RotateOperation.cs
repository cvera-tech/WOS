using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class RotateOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 2)
            {
                var arg3 = stack.Pop();
                var arg2 = stack.Pop();
                var arg1 = stack.Pop();
                stack.Push(arg2);
                stack.Push(arg3);
                stack.Push(arg1);
            }
        }
    }
}