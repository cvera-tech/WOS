using System;
using RpnCalculator.Code;
using System.Collections.Generic;

namespace RpnCalculator
{
    public partial class CalculatorUI : System.Web.UI.Page
    {
        private const string CalculatorViewStateKey = "Calculator";
        private Calculator Calculator
        {
            get
            {
                object o = ViewState[CalculatorViewStateKey];
                if (o != null)
                {
                    return (Calculator)o;
                }
                else
                {
                    return new Calculator();
                }
            }
            set
            {
                ViewState[CalculatorViewStateKey] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calculator = new Calculator();
            }
            NumberInput.Focus();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string[] fourEntries = Calculator.GetFourEntries();
            // Reverse the list for aesthetics
            var things = new List<string>();
            things.AddRange(fourEntries);
            things.Reverse();
            StackViewer.DataSource = things;
            StackViewer.DataBind();
        }

        protected void HandleEnter(object sender, EventArgs e)
        {
            decimal input;
            if (decimal.TryParse(NumberInput.Text, out input))
            {
                Calculator.Push(input);
                NumberInput.Text = string.Empty;
            }
        }

        protected void HandleAdd(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Add);
        }

        protected void HandleMinus(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Minus);
        }

        protected void HandleMultiply(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Multiply);
        }

        protected void HandleDivide(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Divide);
        }

        protected void HandleNegate(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Negate);
        }

        protected void HandleSquareRoot(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.SquareRoot);
        }

        protected void HandleExponential(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Exponential);
        }

        protected void HandlePower(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Power);
        }

        protected void HandleReciprocal(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Reciprocal);
        }

        protected void HandleSine(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Sine);
        }

        protected void HandleCosine(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Cosine);
        }

        protected void HandleDrop(object sender, EventArgs e)
        {
            Calculator.Drop();
        }

        protected void HandleClear(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Clear);
        }

        protected void HandleSwap(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Swap);
        }

        protected void HandleRotate(object sender, EventArgs e)
        {
            Calculator.PerformOperation(OperationType.Rotate);
        }
    }
}