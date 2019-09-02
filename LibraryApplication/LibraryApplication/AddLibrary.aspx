<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLibrary.aspx.cs" Inherits="LibraryApplication.AddLibrary" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:ValidationSummary runat="server" ValidationGroup="AddLibrary" />
    <fieldset>
        <uc:TextBox ID="NameTextBox" runat="server" 
            Label="Library Name: " 
            Required="true" 
            RequiredErrorMessage="Name required." 
            ValidationGroup="AddLibrary" />
        <uc:TextBox ID="AddressLine1TextBox" runat="server" 
            Label="Address Line 1: " 
            Required="true" 
            RequiredErrorMessage="Address line 1 required." 
            ValidationGroup="AddLibrary" />
        <uc:TextBox ID="AddressLine2TextBox" runat="server" 
            Label="Address Line 2: " />
        <uc:TextBox ID="CityTextBox" runat="server" 
            Label="City: " 
            Required="true" 
            RequiredErrorMessage="City required." 
            ValidationGroup="AddLibrary" />
        <uc:DropDownList ID="StateDropDown" runat="server" 
            Label="State: " 
            PrependEmptyItem="true" 
            Required="true"
            RequiredErrorMessage="State required." 
            ValidationGroup="AddLibrary" />
        <uc:TextBox ID="PostalCodeTextBox" runat="server" 
            Label="Postal Code: " 
            Required="true" 
            RequiredErrorMessage="Postal code required." 
            ValidationGroup="AddLibrary" />
        <div>
            <asp:Button ID="AddButton" runat="server" OnCommand="AddButton_Command" Text="Add" ValidationGroup="AddLibrary" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
