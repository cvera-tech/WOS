<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="LibraryApplication.Patrons.List" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <asp:Repeater ID="PatronsRepeater" runat="server"
            ItemType="DataRow">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Email Address</th>
                            <th>Address</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Item.Field<string>("FirstName") %></td>
                    <td><%# Item.Field<string>("LastName") %></td>
                    <td><%# Item.Field<string>("Address") %></td>
                    <td><%# Item.Field<string>("EmailAddress") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Button ID="AddButton" runat="server" 
            OnCommand="AddButton_Command" 
            Text="Add Patron"/>
    </div>
</asp:Content>
