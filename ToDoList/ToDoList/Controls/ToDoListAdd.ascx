<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoListAdd.ascx.cs" Inherits="ToDoList.Controls.ToDoListAdd" %>

<div>
    <asp:TextBox ID="Description" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator runat="server"
        ControlToValidate="Description"
        Display="Dynamic"
        EnableClientScript="true"
        ValidationGroup="ToDoListAdd" 
        ErrorMessage="Please enter a task."
        Text="*" />
    <asp:Button ID="Submit" runat="server"
        Text="Submit" 
        OnClick="Submit_Click" 
        ValidationGroup="ToDoListAdd" />

    <asp:ValidationSummary runat="server"
        ValidationGroup="ToDoListAdd"
        DisplayMode="List" 
        EnableClientScript="true" />
    <div>
        <asp:Label ID="ErrorMessage" runat="server" Text="Please enter a task" Visible="false" />
    </div>
</div>
