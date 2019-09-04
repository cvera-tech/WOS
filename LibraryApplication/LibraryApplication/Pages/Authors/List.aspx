<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="LibraryApplication.Pages.Authors.List" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="LibraryApplication.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Repeater ID="AuthorsRepeater" runat="server"
        ItemType="DataRow">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Field<string>("FirstName") %></td>
                <td><%# Item.Field<string>("LastName") %></td>
                <td>
                    <asp:HyperLink runat="server"
                        NavigateUrl='<%# $"{SitePages.GetUrl(LibraryPage.EditAuthor)}?ID={Item.Field<int>("Id")}" %>'
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
        Text="Add Author" />
</asp:Content>
