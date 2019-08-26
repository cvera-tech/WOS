<%@ Page Title="" Language="C#" MasterPageFile="~/RpnCalculator.Master" AutoEventWireup="true" CodeBehind="CalculatorUI.aspx.cs" Inherits="RpnCalculator.CalculatorUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>RPN Calculator</h1>
    <div>
        <asp:Repeater runat="server" ID="StackViewer" >
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
        <asp:Button runat="server" ID="SquareRoot" OnClick="HandleSquareRoot" Text="sqrt" />
        <asp:Button runat="server" ID="Exponential" OnClick="HandleExponential" Text="e^x" />
        <asp:Button runat="server" ID="Power" OnClick="HandlePower" Text="x^y" />
        <asp:Button runat="server" ID="Reciprocal" OnClick="HandleReciprocal" Text="1/x" />
        <asp:Button runat="server" ID="Sine" OnClick="HandleSine" Text="sin(x)" />
        <asp:Button runat="server" ID="Cosine" OnClick="HandleCosine" Text="cos(x)" />
    </fieldset>
    <fieldset>
        <legend>Stack Operations</legend>
        <asp:Button runat="server" ID="Drop" OnClick="HandleDrop" Text="Drop" />
        <asp:Button runat="server" ID="Clear" OnClick="HandleClear" Text="Clear" />
        <asp:Button runat="server" ID="Swap" OnClick="HandleSwap" Text="Swap" />
        <asp:Button runat="server" ID="Rotate" OnClick="HandleRotate" Text="Rotate" />
    </fieldset>
</asp:Content>
