<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLibrary.aspx.cs" Inherits="LibraryApplication.AddLibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:ValidationSummary runat="server" />
    <fieldset>
        <uc:TextBox ID="NameTextBox" runat="server" Label="Library Name: " Required="true" ErrorMessage="Name required." />
        <uc:TextBox ID="Address1TextBox" runat="server" Label="Address Line 1: " Required="true" ErrorMessage="Address line 1 required." />
        <uc:TextBox ID="Address2TextBox" runat="server" Label="Address Line 2: " />
        <uc:TextBox ID="CityTextBox" runat="server" Label="City: " Required="true" ErrorMessage="City required." />
        <uc:DropDownList ID="StateDropDown" runat="server" Label="State: " />
        <uc:TextBox ID="PostalCodeTextBox" runat="server" Label="Postal Code: " Required="true" ErrorMessage="Postal code required." />
        <div>
            <asp:Button ID="AddButton" runat="server" OnCommand="AddButton_Command" Text="Add" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
