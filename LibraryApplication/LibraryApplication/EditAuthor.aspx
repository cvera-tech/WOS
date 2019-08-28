<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAuthor.aspx.cs" Inherits="LibraryApplication.EditAuthor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <asp:Label ID="OldFirstName" runat="server" />
    </div>
    <div>
        <asp:Label ID="OldLastName" runat="server" />
    </div>
    <fieldset>
        <asp:ValidationSummary runat="server"
            EnableClientScript="true" />

        <div>
            <asp:Label runat="server"
                AssociatedControlID="NewFirstName"
                Text="New First Name: " />
            <asp:TextBox ID="NewFirstName" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="NewFirstName"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="First name required."
                Text="*" />
        </div>
        <div>
            <asp:Label runat="server"
                AssociatedControlID="NewLastName"
                Text="New Last Name: " />
            <asp:TextBox ID="NewLastName" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="NewLastName"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="Last name required."
                Text="*" />
        </div>
        <div>
            <asp:Button ID="SaveButton" runat="server" OnCommand="SaveButton_Command" Text="Save" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
