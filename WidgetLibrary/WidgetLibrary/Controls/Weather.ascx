<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Weather.ascx.cs" Inherits="WidgetLibrary.Controls.Weather" %>

<div>
    <asp:ValidationSummary runat="server"
        ValidationGroup="Weather"
        DisplayMode="BulletList"
        HeaderText="The following errors were found:" />
    <asp:TextBox ID="ZipCode" runat="server" />

    <asp:RequiredFieldValidator runat="server"
        ControlToValidate="ZipCode"
        Display="Dynamic"
        ValidationGroup="Weather"
        EnableClientScript="true"
        ErrorMessage="Please enter a ZIP code."
        Text="*" />
    <asp:RegularExpressionValidator runat="server"
        ControlToValidate="ZipCode"
        ValidationExpression="\d{5}"
        Display="Dynamic"
        ValidationGroup="Weather"
        EnableClientScript="true"
        ErrorMessage="ZIP codes must contain 5 digits" 
        Text="*" />

    <asp:Button ID="Submit"
        runat="server"
        Text="Submit"
        OnClick="Submit_Click"
        ValidationGroup="Weather" />
</div>
<div>
    <asp:Label ID="WeatherDataLabel" runat="server" />
    <asp:Repeater ID="WeatherDataRepeater" runat="server">
        <HeaderTemplate>
            <ul style="list-style: none">
        </HeaderTemplate>
        <ItemTemplate>
            <li><%# Eval("Key") %>: <%# Eval("Value") %></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
