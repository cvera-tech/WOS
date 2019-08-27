using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class MultiplyOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 1)
            {
                var arg2 = stack.Pop();
                var arg1 = stack.Pop();
                try
                {
                    var result = arg1 * arg2;
                    stack.Push(result);
                }
                catch
                {
                    stack.Push(arg1);
                    stack.Push(arg2);
                }
            }
        }
    }
}