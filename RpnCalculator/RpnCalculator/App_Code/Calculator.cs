using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpnCalculator.App_Code
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

        public string[] GetFourEntries()
        {
            List<decimal> firstFour = stack.Take(4).ToList();
            List<string> firstFourStrings = new List<string>();
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
    }
}