using System;
using RpnCalculator.App_Code;

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
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string[] fourEntries = Calculator.GetFourEntries();
            StackViewer.DataSource = fourEntries;
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

        }

        protected void HandleMinus(object sender, EventArgs e)
        {

        }

        protected void HandleMultiply(object sender, EventArgs e)
        {

        }

        protected void HandleDivide(object sender, EventArgs e)
        {

        }

        protected void HandleNegate(object sender, EventArgs e)
        {

        }

        protected void HandleDrop(object sender, EventArgs e)
        {

        }
    }
}