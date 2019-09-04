<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="LibraryApplication.Pages.Librarians.List" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="LibraryApplication.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Repeater ID="LibrariansRepeater" runat="server"
        ItemType="DataRow">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Library</th>
                        <th>Address</th>
                        <th>Email Address</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Field<string>("FirstName") %></td>
                <td><%# Item.Field<string>("LastName") %></td>
                <td><%# Item.Field<string>("LibraryName") %></td>
                <td><%# Item.Field<string>("StreetAddress") %></td>
                <td><%# Item.Field<string>("EmailAddress") %></td>
                <td><asp:HyperLink runat="server" 
                    NavigateUrl='<%# $"{SitePages.GetUrl(LibraryPage.EditLibrarian)}?ID={Item.Field<int>("Id")}"%>' 
                    Text="Edit" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div>
        <asp:Button ID="AddButton" runat="server" 
            OnCommand="AddButton_Command"
            Text="Add Librarian" />
    </div>
</asp:Content>
