<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="LibraryApplication.Pages.Books.List" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="LibraryApplication.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Repeater ID="BooksRepeater" runat="server"
        ItemType="DataRow">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>ISBN</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Field<string>("Title") %></td>
                <td><%# Item.Field<string>("AuthorName") %></td>
                <td><%# Item.Field<string>("Isbn") %></td>
                <td>
                    <asp:HyperLink runat="server"
                        NavigateUrl='<%# $"{SitePages.GetUrl(LibraryPage.EditBook)}?ID={Item.Field<int>("Id")}" %>'
                        Text="Edit"
                        Visible='<%# User.IsInRole("Librarian") %>' />
                </td>
                <td>
                    <asp:HyperLink runat="server"
                        NavigateUrl='<%# $"{SitePages.GetUrl(LibraryPage.BookCopies)}?ID={Item.Field<int>("Id")}" %>'
                        Text="View Copies" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button runat="server"
        ID="AddButton"
        OnCommand="AddButton_Command"
        Text="Add Book" />
</asp:Content>
