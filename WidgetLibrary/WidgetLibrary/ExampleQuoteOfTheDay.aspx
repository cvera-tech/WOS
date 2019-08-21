<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExampleQuoteOfTheDay.aspx.cs" Inherits="WidgetLibrary.ExampleQuoteOfTheDay" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
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
    <jwl:QuoteOfTheDay runat="server" Randomize="true" />
    <p>
        <a href="Default.aspx">Return to Home</a>
    </p>
</asp:Content>
