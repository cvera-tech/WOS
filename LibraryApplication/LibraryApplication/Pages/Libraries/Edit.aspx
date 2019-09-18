<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LibraryApplication.Pages.Libraries.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <div>
            <label>Current name: </label>
            <asp:Label ID="OldName" runat="server" />
        </div>
        <div>
            <label>Current address: </label>
            <asp:Label ID="OldAddress" runat="server" />
        </div>
    </div>
    <fieldset>
        <uc:TextBox ID="NewNameTextBox" runat="server" 
            Label="Library Name: " 
            Required="true" 
            RequiredErrorMessage="Name required." 
            ValidationGroup="EditLibrary" />
        <uc:TextBox ID="NewAddressLine1TextBox" runat="server" 
            Label="Address Line 1: " 
            Required="true" 
            RequiredErrorMessage="Address line 1 required." 
            ValidationGroup="EditLibrary" />
        <uc:TextBox ID="NewAddressLine2TextBox" runat="server" 
            Label="Address Line 2: " />
        <uc:TextBox ID="NewCityTextBox" runat="server" 
            Label="City: " 
            Required="true" 
            RequiredErrorMessage="City required." 
            ValidationGroup="EditLibrary" />
        <uc:DropDownList ID="NewStateDropDown" runat="server" 
            Label="State: " 
            Required="true" 
            RequiredErrorMessage="State required."
            ValidationGroup="EditLibrary" />
        <uc:TextBox ID="NewPostalCodeTextBox" runat="server" 
            Label="Postal Code: " 
            Required="true" 
            RequiredErrorMessage="Postal code required." 
            ValidationGroup="EditLibrary" />
        <div>
            <asp:Button ID="SaveButton" runat="server" OnCommand="SaveButton_Command" Text="Save" ValidationGroup="EditLibrary" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
