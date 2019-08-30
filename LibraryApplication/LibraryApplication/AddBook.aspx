<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryApplication.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script>
        function AuthorValidation(sender, arguments) {
            var selectedAuthor = $('#<%= AuthorDropDown.ClientID%>').val();
            if (selectedAuthor === '') {
                arguments.IsValid = false;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="AddBook"
            EnableClientScript="true" />
        <asp:CustomValidator runat="server"
            ValidationGroup="AddBook"
            EnableClientScript="true"
            ClientValidationFunction="AuthorValidation"
            ErrorMessage="Author required."
            Display="None"
            Text="" />

        <div>
            <asp:Label runat="server"
                AssociatedControlID="TitleTextBox"
                Text="Title: " />
            <asp:TextBox ID="TitleTextBox" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="TitleTextBox"
                ValidationGroup="AddBook"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="Title required."
                Text="*" />
        </div>
        <uc:DropDownList ID="AuthorDropDown" runat="server"
            Label="Author: "
            PrependEmptyItem="true" />
        <div>
            <asp:Label runat="server"
                AssociatedControlID="ISBN"
                Text="ISBN: " />
            <asp:TextBox ID="ISBN" runat="server" />
        </div>
        <div>
            <asp:Button ID="AddButton" runat="server" 
                OnCommand="AddButton_Command" 
                ValidationGroup="AddBook"
                Text="Add" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
