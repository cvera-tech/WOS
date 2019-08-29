<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LibraryApplication.Books" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Repeater ID="BooksRepeater" runat="server"
        ItemType="DataRow">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>ISBN</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Field<string>("Title") %></td>
                <td><%# Item.Field<string>("AuthorName") %></td>
                <td><%# Item.Field<string>("Isbn") %></td>
                <td>
                    <asp:HyperLink runat="server"
                        NavigateUrl='<%# $"~/EditBook.aspx?ID={Item.Field<int>("Id")}" %>'
                        Text="Edit" />
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
