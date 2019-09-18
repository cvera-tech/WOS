<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabeledDropDownList.ascx.cs" Inherits="LibraryApplication.Controls.LabeledDropDownList" %>

<div>
    <asp:Label ID="ControlLabel" runat="server"
        AssociatedControlID="ControlDropDownList" />
    <asp:DropDownList ID="ControlDropDownList" runat="server">
        <asp:ListItem ID="ControlEmptyItem" runat="server"></asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="ControlValidator" runat="server"
        ControlToValidate="ControlDropDownList"
        EnableClientScript="true"
        Display="Dynamic"
        ErrorMessage="Field required."
        Text="*"
        Enabled="false" />
</div>
