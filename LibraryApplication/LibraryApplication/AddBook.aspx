<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryApplication.AddBook" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset>
        <asp:ValidationSummary runat="server"
            ValidationGroup="AddBook"
            EnableClientScript="true" />
        
        <uc:TextBox ID="TitleTextBox" runat="server" 
            Label="Title: "
            Required="true"
            RequiredErrorMessage="Title required." 
            ValidationGroup="AddBook" />
        <uc:DropDownList ID="AuthorDropDown" runat="server"
            Label="Author: "
            PrependEmptyItem="true" 
            ValidationGroup="AddBook"
            Required="true" 
            RequiredErrorMessage="Author required."/>
        <uc:TextBox ID="ISBN" runat="server"
            Label="ISBN" />
        <div>
            <asp:Button ID="AddButton" runat="server" 
                OnCommand="AddButton_Command" 
                ValidationGroup="AddBook"
                Text="Add" />
            <asp:Button ID="CancelButton" runat="server" OnCommand="CancelButton_Command" Text="Cancel" />
        </div>
    </fieldset>
</asp:Content>
