<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleFontPreview.aspx.cs" Inherits="WidgetLibrary.ExampleFontPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Font Preview</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Font Preview</h1>
            <p>This widget gives a preview of a font by applying it to sample text.</p>
            <h2>Properties</h2>
            <dl>
                <dt>LoremType</dt>
                <dd>The type of lorem ipsum text to apply the font to. Possible values are: 'Lorem', 'Sagan', 'Hipster', and 'Pirate'. Defaults to 'Lorem'</dd>
            </dl>
            <h2>Examples</h2>
            <pre>&lt;jwl:FontPreview runat="server" /&gt;</pre>
            <jwl:FontPreview runat="server" />
            <pre>&lt;jwl:FontPreview runat="server" Type="Sagan" /&gt;</pre>
            <jwl:FontPreview runat="server" LoremType="Sagan" />
            <pre>&lt;jwl:FontPreview runat="server" Type="Hipster" /&gt;</pre>

            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
