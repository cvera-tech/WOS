using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetLibrary.Controls
{
    public partial class Counter : System.Web.UI.UserControl
    {
        public int Count
        {
            get
            {
                object o = ViewState["Count"];
                if (o != null)
                {
                    return (int)o;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["Count"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CounterLabel.Text = Count.ToString();
            }
        }

        protected void IncrementButton_Click(object sender, EventArgs e)
        {
            Count++;
            CounterLabel.Text = Count.ToString();
        }

        protected void DecrementButton_Click(object sender, EventArgs e)
        {
            
            Count--;
            CounterLabel.Text = Count.ToString();
        }
        

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (ViewState["Count"] != null)
        //        {
        //            Count = (int)ViewState["Count"];
        //            Count = int.Parse(ViewState["Count"].ToString());
        //        }
        //        else
        //        {
        //            Count = 0;
        //            SetViewStateVariable();
        //        }
        //        CounterLabel.Text = Count.ToString();
        //    }
        //}

        //protected void IncrementButton_Click(object sender, EventArgs e)
        //{
        //    Count = int.Parse(ViewState["Count"].ToString());
        //    Count++;
        //    SetViewStateVariable();
        //    CounterLabel.Text = Count.ToString();
        //}

        //protected void DecrementButton_Click(object sender, EventArgs e)
        //{
        //    Count = int.Parse(ViewState["Count"].ToString());
        //    Count--;
        //    SetViewStateVariable();
        //    CounterLabel.Text = Count.ToString();
        //}

        //private void SetViewStateVariable()
        //{
        //    ViewState["Count"] = Count;
        //}
    }
}