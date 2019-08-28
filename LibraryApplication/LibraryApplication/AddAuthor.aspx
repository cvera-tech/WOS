<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAuthor.aspx.cs" Inherits="LibraryApplication.AddAuthor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <fieldset>
        <asp:ValidationSummary runat="server"
            EnableClientScript="true" />

        <div>
            <asp:Label runat="server"
                AssociatedControlID="FirstName"
                Text="First Name: " />
            <asp:TextBox ID="FirstName" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="FirstName"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="First name required."
                Text="*" />
        </div>
        <div>
            <asp:Label runat="server"
                AssociatedControlID="LastName"
                Text="Last Name: " />
            <asp:TextBox ID="LastName" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="LastName"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="Last name required."
                Text="*" />
        </div>
        <div>
            <asp:Button ID="AddButton" runat="server" OnCommand="AddButton_Command" Text="Add" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
