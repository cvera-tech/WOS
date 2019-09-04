<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LibraryApplication.Pages.Books.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <label>Current title: </label>
        <asp:Label ID="OldTitle" runat="server" />
    </div>
    <div>
        <label>Current author: </label>
        <asp:Label ID="OldAuthor" runat="server" />
    </div>
    <div>
        <label>Current ISBN: </label>
        <asp:Label ID="OldIsbn" runat="server" />
    </div>
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="EditBook"
            EnableClientScript="true" />
        <uc:TextBox ID="TitleTextBox" runat="server" 
            Label="Title: " 
            Required="true" 
            RequiredErrorMessage="Title required."
            ValidationGroup="EditBook"/>
        <uc:DropDownList ID="AuthorDropDown" runat="server" 
            Label="Author: " 
            Required="true"
            RequiredErrorMessage="Author required."
            ValidationGroup="EditBook" />
        <uc:TextBox ID="IsbnTextBox" runat="server" 
            Label="ISBN: " />
        <div>
            <asp:Button ID="SaveButton" runat="server" 
                OnCommand="SaveButton_Command" 
                Text="Save" 
                ValidationGroup="EditBook"/>
            <asp:Button ID="CancelButton" runat="server" 
                OnCommand="CancelButton_Command" 
                Text="Cancel"/>
        </div>
    </fieldset>
</asp:Content>
