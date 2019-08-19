<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDoList.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>TODOs</h1>

            <asp:Repeater ID="TODOs" runat="server" OnItemCommand="TODOs_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <th>Description</th>
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

            <h2>Add New TODO</h2>
            <asp:TextBox ID="Description" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            <div>
                <asp:Label ID="ErrorMessage" runat="server" Text="Please enter a task" Visible="false" />
            </div>
        </div>
    </form>
</body>
</html>
