<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LibraryApplication.Pages.Patrons.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="AddPatron"
            EnableClientScript="true" />
        <uc:TextBox ID="FirstNameTextBox" runat="server"
            Label="First Name: "
            Required="true"
            RequiredErrorMessage="First name required."
            ValidationGroup="AddPatron" />
        <uc:TextBox ID="LastNameTextBox" runat="server"
            Label="Last Name: "
            Required="true"
            RequiredErrorMessage="Last name required."
            ValidationGroup="AddPatron" />
        <uc:TextBox ID="EmailAddressTextBox" runat="server"
            Label="Email Address: "
            Required="true"
            RequiredErrorMessage="Email address required."
            ValidationGroup="AddPatron" />
        <uc:TextBox ID="AddressLine1TextBox" runat="server"
            Label="Address Line 1: "
            Required="true"
            RequiredErrorMessage="Address line 1 required."
            ValidationGroup="AddPatron" />
        <uc:TextBox ID="AddressLine2TextBox" runat="server"
            Label="Address Line 2: " />
        <uc:TextBox ID="CityTextBox" runat="server"
            Label="City: "
            Required="true"
            RequiredErrorMessage="City required."
            ValidationGroup="AddPatron" />
        <uc:DropDownList ID="StateDropDownList" runat="server"
            Label="State: "
            Required="true"
            RequiredErrorMessage="State required."
            ValidationGroup="AddPatron"
            PrependEmptyItem="true" />
        <uc:TextBox ID="PostalCodeTextBox" runat="server"
            Label="Postal Code: "
            Required="true"
            RequiredErrorMessage="Postal code required."
            ValidationGroup="AddPatron" />
        <div>
            <asp:Button ID="AddButton" runat="server"
                OnCommand="AddButton_Command"
                Text="Add patron"
                ValidationGroup="AddPatron" />
            <asp:Button ID="CancelButton" runat="server"
                OnCommand="CancelButton_Command"
                Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
