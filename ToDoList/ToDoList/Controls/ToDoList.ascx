<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.ascx.cs" Inherits="ToDoList.Controls.ToDoList" %>
<div>
    <asp:Repeater ID="TODOs" runat="server" OnItemCommand="TODOs_ItemCommand">
        <HeaderTemplate>
            <table>
                <th>Tasks</th>
                <th>&nbsp;</th>
                <th>&nbsp;</th>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server"
                        ID="Description"
                        Text='<%# Eval("Description") %>'
                        Font-Strikeout='<%# Eval("Done") %>' />
                </td>
                <td>
                    <asp:Label runat="server"
                        ID="Category"
                        Text='<%# Eval("Category") %>' />
                </td>
                <td>
                    <asp:Button runat="server"
                        ID="Done"
                        Text="Done"
                        CommandName="Done"
                        CommandArgument='<%# Container.ItemIndex %>'
                        Visible='<%# !((bool)Eval("Done")) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button runat="server"
        ID="PreviousButton"
        Text="<"
        OnClick="PreviousButton_Click" />
    <asp:Button runat="server"
        ID="NextButton"
        Text=">"
        OnClick="NextButton_Click" />
    <asp:DropDownList runat="server"
        ID="CategoryDropDown"
        AutoPostBack="true"
        OnSelectedIndexChanged="CategoryDropDown_SelectedIndexChanged" />
</div>

