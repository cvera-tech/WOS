<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExampleFontPreview.aspx.cs" Inherits="WidgetLibrary.ExampleFontPreview" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
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

    <p>
        <a href="Default.aspx">Return to Home</a>
    </p>
</asp:Content>
