using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class ExponentialOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            if (stack.Count > 0)
            {
                var arg = stack.Pop();
                try
                {
                    var result = Math.Exp(decimal.ToDouble(arg));
                    stack.Push((decimal)result);
                }
                catch
                {
                    stack.Push(arg);
                }
            }
        }
    }
}