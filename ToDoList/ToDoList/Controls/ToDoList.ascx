<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.ascx.cs" Inherits="ToDoList.Controls.ToDoList" %>
<div>
    <asp:Repeater ID="TODOs" runat="server" OnItemCommand="TODOs_ItemCommand">
        <HeaderTemplate>
            <table>
                <th>Tasks</th>
                <th>&nbsp;</th>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label
                        ID="Description"
                        runat="server"
                        Text='<%# Eval("Description") %>'
                        Font-Strikeout='<%# Eval("Done") %>' />
                </td>
                <td>
                    <asp:Button
                        ID="Done"
                        runat="server"
                        Text="Done"
                        CommandName="Done"
                        CommandArgument='<%# Container.ItemIndex %>'
                        Visible='<%# !((bool)Eval("Done")) %>' /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>

