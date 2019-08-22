<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoListAdd.ascx.cs" Inherits="ToDoList.Controls.ToDoListAdd" %>

<div>
    <asp:Label runat="server"
        ID="DescriptionLabel"
        AssociatedControlID="Description" 
        Text="Description: " />
    <asp:TextBox runat="server" ID="Description" />
    <asp:Label runat="server"
        ID="CategoriesLabel"
        AssociatedControlID="Category"
        Text="Category: " />
    <asp:DropDownList runat="server"
        ID="Category" />
    <asp:RequiredFieldValidator runat="server"
        ControlToValidate="Description"
        Display="Dynamic"
        EnableClientScript="true"
        ValidationGroup="ToDoListAdd" 
        ErrorMessage="Please enter a task."
        Text="*" />
    <asp:Button runat="server"
        ID="Submit"
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
