<%@ Page Title="" Language="C#" MasterPageFile="~/RpnCalculator.Master" AutoEventWireup="true" CodeBehind="CalculatorUI.aspx.cs" Inherits="RpnCalculator.CalculatorUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>RPN Calculator</h1>
    <div>
        <asp:Repeater runat="server" ID="StackViewer">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><%# Container.DataItem %></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <section>
        <asp:TextBox runat="server" ID="NumberInput" />
        <asp:Button runat="server" ID="Enter" OnClick="HandleEnter" Text="Enter" />
    </section>
    <fieldset>
        <legend>Math Operations</legend>
        <asp:Button runat="server" ID="Add" OnClick="HandleAdd" Text="+" />
        <asp:Button runat="server" ID="Minus" OnClick="HandleMinus" Text="-" />
        <asp:Button runat="server" ID="Multiply" OnClick="HandleMultiply" Text="*" />
        <asp:Button runat="server" ID="Divide" OnClick="HandleDivide" Text="/" />
        <asp:Button runat="server" ID="Negate" OnClick="HandleNegate" Text="+/-" />
    </fieldset>
    <fieldset>
        <legend>Stack Operations</legend>
        <asp:Button runat="server" ID="Drop" OnClick="HandleDrop" Text="Drop" />
    </fieldset>
</asp:Content>
