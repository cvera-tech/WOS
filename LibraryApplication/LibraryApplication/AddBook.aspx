<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryApplication.AddBook" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset>
        <asp:ValidationSummary runat="server"
            EnableClientScript="true" />

        <div>
            <asp:Label runat="server"
                AssociatedControlID="TitleTextBox"
                Text="Title: " />
            <asp:TextBox ID="TitleTextBox" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="TitleTextBox"
                EnableClientScript="true"
                Display="Dynamic"
                ErrorMessage="Title required."
                Text="*" />
        </div>
        <div>
            <asp:Label runat="server"
                AssociatedControlID="AuthorDropDown"
                Text="Author: " />
            <asp:DropDownList ID="AuthorDropDown" runat="server"
                AutoPostBack="false"
                AppendDataBoundItems="true">
                <asp:ListItem Enabled="false"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server"
                AssociatedControlID="ISBN"
                Text="ISBN: " />
            <asp:TextBox ID="ISBN" runat="server" />
        </div>
        <div>
            <asp:Button ID="AddButton" runat="server" OnCommand="AddButton_Command" Text="Add" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
