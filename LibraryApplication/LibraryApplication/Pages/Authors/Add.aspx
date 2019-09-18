<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LibraryApplication.Pages.Authors.Add" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <fieldset>
        <asp:ValidationSummary runat="server"
            EnableClientScript="true" 
            ValidationGroup="AddAuthor"/>
        <uc:TextBox ID="FirstName" runat="server"
            Label="First Name: "
            Required="true"
            RequiredErrorMessage="First name required."
            ValidationGroup="AddAuthor" />
        <uc:TextBox ID="LastName" runat="server"
            Label="Last Name: "
            Required="true"
            RequiredErrorMessage="Last name required."
            ValidationGroup="AddAuthor" />
        <div>
            <asp:Button ID="AddButton" runat="server" OnCommand="AddButton_Command" Text="Add" ValidationGroup="AddAuthor" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
