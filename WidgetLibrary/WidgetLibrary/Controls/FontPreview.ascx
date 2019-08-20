<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FontPreview.ascx.cs" Inherits="WidgetLibrary.Controls.FontPreview" %>

<div>
    <asp:DropDownList ID="FontList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FontList_SelectedIndexChanged" />
    <p>
        <asp:Label ID="FillerText" runat="server" />
    </p>
</div>

