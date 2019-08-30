<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="LibraryApplication.EditBook" %>

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
        <uc:TextBox ID="TitleTextBox" runat="server" Label="Title: " Required="true" RequiredErrorMessage="Title required."/>
        <uc:DropDownList ID="AuthorDropDown" runat="server" Label="Author: " />
        <uc:TextBox ID="IsbnTextBox" runat="server" Label="ISBN: " />
        <div>
            <asp:Button ID="SaveButton" runat="server" 
                OnCommand="SaveButton_Command" 
                Text="Save" />
            <asp:Button ID="CancelButton" runat="server" 
                OnCommand="CancelButton_Command" 
                Text="Cancel"/>
        </div>
    </fieldset>
</asp:Content>
