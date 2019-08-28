<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="LibraryApplication.Authors" %>
<%@ import namespace="System.Data" %>

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
                    NavigateUrl='<%# $"~/EditAuthor.aspx?ID={Item.Field<int>("Id")}" %>' 
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
