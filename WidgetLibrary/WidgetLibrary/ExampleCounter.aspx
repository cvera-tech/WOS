<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleCounter.aspx.cs" Inherits="WidgetLibrary.ExampleCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Counter Widget</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Counter</h1>
            <p>This widget displays a counter.</p>
            <h2>Examples</h2>
            <pre>&lt;jwl:Counter runat="server" /&gt;</pre>
            <jwl:Counter runat="server" />
            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
