<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleRenderTime.aspx.cs" Inherits="WidgetLibrary.ExampleRenderTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Render Time Widget</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Render Time</h1>
            <p>This widget displays the time when the page was rendered.</p>
            <h2>Properties</h2>
            <dl>
                <dt>Label</dt>
                <dd>A message to be prepended to the time. Defaults to "Page rendered at: "</dd>
                <dt>Format</dt>
                <dd>A string for formatting the DateTime object. Defaults to "M/d/yyyy h:mm tt"</dd>
            </dl>
            <h2>Examples</h2>
            <pre>&lt;jwl:RenderTime runat="server" /&gt;</pre>
            <jwl:RenderTime runat="server" />
            <pre>&lt;jwl:RenderTime runat="server" Label="This is a custom label! " Format="yy/M/d hh:mm:ss"</pre>
            <jwl:RenderTime runat="server" Label="This is a custom label! " Format="yy/M/d hh:mm:ss" />
            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
