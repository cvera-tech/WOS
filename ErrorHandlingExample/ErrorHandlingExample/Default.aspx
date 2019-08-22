<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ErrorHandlingExample._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="Number1"></asp:TextBox>
    <asp:TextBox runat="server" ID="Number2"></asp:TextBox>
    <asp:Button runat="server" ID="Sum" OnClick="Sum_Click" />
    <asp:Label runat="server" ID="Result"></asp:Label>
</asp:Content>
