using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.Code.Operations
{
    public class ClearOperation : IOperation
    {
        public void Perform(Stack<decimal> stack)
        {
            stack.Clear();
        }
    }
}