<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExampleCounter.aspx.cs" Inherits="WidgetLibrary.ExampleCounter" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Counter</h1>
    <p>This widget displays a counter.</p>
    <h2>Examples</h2>
    <pre>&lt;jwl:Counter runat="server" /&gt;</pre>
    <jwl:Counter runat="server" />
    <p>
        <a href="Default.aspx">Return to Home</a>
    </p>
</asp:Content>