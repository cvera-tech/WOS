<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleQuoteOfTheDay.aspx.cs" Inherits="WidgetLibrary.ExampleQuoteOfTheDay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Quote of the Day</h1>
            <p>This widget displays a quote for the day.</p>
            <h2>Properties</h2>
            <dl>
                <dt>Randomize</dt>
                <dd>A flag to determine whether or not to load a new quote when the page is refreshed. Defaults to false.</dd>
            </dl>
            <h2>Examples</h2>
            <pre>&lt;jwl:QuoteOfTheDay runat="server" /&gt;</pre>
            <jwl:QuoteOfTheDay runat="server" />
            <pre>&lt;jwl:QuoteOfTheDay runat="server" Randomize="true" /&gt;</pre>
            <jwl:QuoteOfTheDay runat="server" Randomize="true"/>
            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
