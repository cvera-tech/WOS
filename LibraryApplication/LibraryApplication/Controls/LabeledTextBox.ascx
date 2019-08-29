<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabeledTextBox.ascx.cs" Inherits="LibraryApplication.Controls.LabeledTextBox" %>

<div>
    <asp:Label ID="ControlLabel" runat="server"
        AssociatedControlID="ControlTextBox" />
    <asp:TextBox ID="ControlTextBox" runat="server" />
    <asp:RequiredFieldValidator ID="ControlValidator" runat="server"
        ControlToValidate="ControlTextBox"
        EnableClientScript="true"
        Display="Dynamic"
        ErrorMessage="Title required."
        Text="*" 
        Enabled="false" />
</div>
