<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleWeather.aspx.cs" Inherits="WidgetLibrary.ExampleWeather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weather</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Weather</h1>
            <p>This widget displays the weather at a given input ZIP code.</p>
            <h2>Examples</h2>
            <pre>&lt;jwl:Weather runat="server" /&gt;</pre>
            <jwl:Weather runat="server" />
            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
