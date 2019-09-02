<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLibrarian.aspx.cs" Inherits="LibraryApplication.AddLibrarian" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="AddLibrarian"
            EnableClientScript="true" />
        <uc:TextBox ID="FirstNameTextBox" runat="server"
            Label="First Name: "
            Required="true"
            RequiredErrorMessage="First name required."
            ValidationGroup="AddLibrarian" />
        <uc:TextBox ID="LastNameTextBox" runat="server"
            Label="Last Name: "
            Required="true"
            RequiredErrorMessage="Last name required."
            ValidationGroup="AddLibrarian" />
        <uc:TextBox ID="EmailAddressTextBox" runat="server"
            Label="Email Address: "
            Required="true"
            RequiredErrorMessage="Email address required."
            ValidationGroup="AddLibrarian" />
        <uc:DropDownList ID="LibraryDropDownList" runat="server"
            Label="Library: "
            Required="true"
            RequiredErrorMessage="Library required."
            ValidationGroup="AddLibrarian"
            PrependEmptyItem="true" />
        <uc:TextBox ID="AddressLine1TextBox" runat="server"
            Label="Address Line 1: "
            Required="true"
            RequiredErrorMessage="Address line 1 required."
            ValidationGroup="AddLibrarian" />
        <uc:TextBox ID="AddressLine2TextBox" runat="server"
            Label="Address Line 2: " />
        <uc:TextBox ID="CityTextBox" runat="server"
            Label="City: "
            Required="true"
            RequiredErrorMessage="City required."
            ValidationGroup="AddLibrarian" />
        <uc:DropDownList ID="StateDropDownList" runat="server"
            Label="State: " 
            Required="true"
            RequiredErrorMessage="State required."
            ValidationGroup="AddLibrarian"
            PrependEmptyItem="true" />
        <uc:TextBox ID="PostalCodeTextBox" runat="server"
            Label="Postal Code: "
            Required="true"
            RequiredErrorMessage="Postal code required."
            ValidationGroup="AddLibrarian" />
        <div>
            <asp:Button ID="AddButton" runat="server" 
                OnCommand="AddButton_Command"
                Text="Add librarian" 
                ValidationGroup="AddLibrarian" />
            <asp:Button ID="CancelButton" runat="server"
                OnCommand="CancelButton_Command"
                Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
