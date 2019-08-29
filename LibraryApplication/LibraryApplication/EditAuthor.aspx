<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAuthor.aspx.cs" Inherits="LibraryApplication.EditAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script>
        function TextBoxValidation(sender, arguments) {
            var oldFirstName = $('#<%= OldFirstName.ClientID %>').text();
            var oldLastName = $('#<%= OldLastName.ClientID %>').text();
            var newFirstName = $('#<%= NewFirstName.ClientID %>').val();
            var newLastName = $('#<%= NewLastName.ClientID %>').val();

            // Make sure the fields are not null
            if (oldFirstName && newFirstName && oldLastName && newLastName) {
                // Do not make any queries if the strings have not changed
                if (oldFirstName === newFirstName && oldLastName === newLastName) {
                    arguments.IsValid = false;
                }
                else {
                    arguments.IsValid = true;
                }
            }
            else {
                arguments.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <label>Current first name: </label>
        <asp:Label ID="OldFirstName" runat="server" />
    </div>
    <div>
        <label>Current last name: </label>
        <asp:Label ID="OldLastName" runat="server" />
    </div>
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="EditAuthor"
            EnableClientScript="true" />
        <asp:CustomValidator runat="server"
            ValidationGroup="EditAuthor"
            EnableClientScript="true"
            ClientValidationFunction="TextBoxValidation"
            ErrorMessage="First or last name must be changed."
            Display="None"
            Text="" />

        <div>
            <asp:Label runat="server"
                AssociatedControlID="NewFirstName"
                Text="New First Name: " />
            <asp:TextBox ID="NewFirstName" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="NewFirstName"
                ValidationGroup="EditAuthor"
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
                ValidationGroup="EditAuthor"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="Last name required."
                Text="*" />
        </div>
        <div>
            <asp:Button ID="SaveButton" runat="server" 
                OnCommand="SaveButton_Command" 
                Text="Save" 
                ValidationGroup="EditAuthor"/>
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
