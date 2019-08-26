using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WidgetLibrary.Data;

namespace WidgetLibrary.Controls
{
    public partial class Weather : System.Web.UI.UserControl
    {
        private const string WeatherDataErrorMessage = "ERROR: Unable to retrieve weather data";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WeatherDataLabel.Visible = false;
                WeatherDataRepeater.Visible = false;
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string zipCode = ZipCode.Text;
                Dictionary<string, string> weatherData = WeatherData.CallApi(zipCode);
                if (weatherData != null)
                {
                    WeatherDataLabel.Visible = false;
                    WeatherDataRepeater.Visible = true;
                    WeatherDataRepeater.DataSource = weatherData;
                    WeatherDataRepeater.DataBind();
                }
                else
                {
                    WeatherDataLabel.Visible = true;
                    WeatherDataLabel.Text = WeatherDataErrorMessage;
                    WeatherDataRepeater.Visible = false;
                }
            }
        }
    }
}