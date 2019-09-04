<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LibraryApplication.Pages.Librarians.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <div>
            <label>Current name: </label>
            <asp:Label ID="OldName" runat="server" />
        </div>
        <div>
            <label>Current email address: </label>
            <asp:Label ID="OldEmailAddress" runat="server" />
        </div>
        <div>
            <label>Current library: </label>
            <asp:Label ID="OldLibrary" runat="server" />
        </div>
        <div>
            <label>Current address: </label>
            <asp:Label ID="OldAddress" runat="server" />
        </div>
    </div>
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="EditLibrarian"
            EnableClientScript="true" />
        <uc:TextBox ID="NewFirstNameTextBox" runat="server"
            Label="First Name: "
            Required="true"
            RequiredErrorMessage="First name required."
            ValidationGroup="EditLibrarian" />
        <uc:TextBox ID="NewLastNameTextBox" runat="server"
            Label="Last Name: "
            Required="true"
            RequiredErrorMessage="Last name required."
            ValidationGroup="EditLibrarian" />
        <uc:TextBox ID="NewEmailAddressTextBox" runat="server"
            Label="Email Address: "
            Required="true"
            RequiredErrorMessage="Email address required."
            ValidationGroup="EditLibrarian" />
        <uc:DropDownList ID="NewLibraryDropDownList" runat="server"
            Label="Library: "
            Required="true"
            RequiredErrorMessage="Library required."
            ValidationGroup="EditLibrarian"/>
        <uc:TextBox ID="NewAddressLine1TextBox" runat="server"
            Label="Address Line 1: "
            Required="true"
            RequiredErrorMessage="Address line 1 required."
            ValidationGroup="EditLibrarian" />
        <uc:TextBox ID="NewAddressLine2TextBox" runat="server"
            Label="Address Line 2: " />
        <uc:TextBox ID="NewCityTextBox" runat="server"
            Label="City: "
            Required="true"
            RequiredErrorMessage="City required."
            ValidationGroup="EditLibrarian" />
        <uc:DropDownList ID="NewStateDropDownList" runat="server"
            Label="State: " 
            Required="true"
            RequiredErrorMessage="State required."
            ValidationGroup="EditLibrarian" />
        <uc:TextBox ID="NewPostalCodeTextBox" runat="server"
            Label="Postal Code: "
            Required="true"
            RequiredErrorMessage="Postal code required."
            ValidationGroup="EditLibrarian" />
        <div>
            <asp:Button ID="SaveButton" runat="server" 
                OnCommand="SaveButton_Command"
                Text="Save librarian" 
                ValidationGroup="EditLibrarian" />
            <asp:Button ID="CancelButton" runat="server"
                OnCommand="CancelButton_Command"
                Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
