<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Copies.aspx.cs" Inherits="LibraryApplication.Pages.Books.Copies" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <label>Book Title: </label>
        <asp:Label ID="BookTitleLabel" runat="server" />
    </div>
    <div>
        <label>Author: </label>
        <asp:Label ID="AuthorLabel" runat="server" />
    </div>
    <div>
        <label>ISBN: </label>
        <asp:Label ID="IsbnLabel" runat="server" />
    </div>
    <div>
        <asp:Repeater ID="BookCopiesRepeater" runat="server"
            ItemType="DataRow">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Library</th>
                            <th>Available</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server"
                            Text='<%# Item.Field<string>("LibraryName") %>'
                            Font-Strikeout='<%# !Item.Field<bool>("Available") %>' />
                    </td>
                    <td>
                        <asp:CheckBox runat="server"
                            AutoPostBack="true"
                            Checked='<%# Item.Field<bool>("Available") %>'
                            OnCheckedChanged="Available_CheckedChanged" />
                    </td>
                    <td hidden="hidden">
                        <asp:Label ID="BookCopyId" runat="server" Text='<%# Item.Field<int>("Id") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <div>
            <h3>Add Book Copy</h3>
        </div>
        <fieldset>
            <uc:DropDownList ID="LibrariesDropDownList" runat="server"
                Label="Library: "
                PrependEmptyItem="true"
                Required="true"
                RequiredErrorMessage="Library required."
                ValidationGroup="AddBookCopy" />
            <%-- TODO LabeledCheckBox user control --%>
            <div>
                <asp:Label runat="server" Text="Available: " />
                <asp:CheckBox ID="AvailableCheckBox" runat="server" />
            </div>
            <asp:Button ID="AddButton" runat="server"
                OnCommand="AddButton_Command"
                Text="Add" />
        </fieldset>
    </div>
</asp:Content>
