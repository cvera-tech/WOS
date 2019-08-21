<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExampleWeather.aspx.cs" Inherits="WidgetLibrary.ExampleWeather" Title="Weather Widget Example" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Weather</h1>
    <p>This widget displays the weather at a given input ZIP code.</p>
    <h2>Examples</h2>
    <pre>&lt;jwl:Weather runat="server" /&gt;</pre>
    <jwl:Weather runat="server" />
    <p>
        <a href="Default.aspx">Return to Home</a>
    </p>
</asp:Content>
