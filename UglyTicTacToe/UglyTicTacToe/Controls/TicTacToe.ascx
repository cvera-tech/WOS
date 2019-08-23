<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicTacToe.ascx.cs" Inherits="UglyTicTacToe.Controls.TicTacToe" %>

<asp:Image runat="server" ImageUrl="~/Images/deepfriedLogo.png"/>
<%--
<asp:ImageButton runat="server" ImageUrl="~/Images/deepfriedBlank.png" />
<asp:ImageButton runat="server" ImageUrl="~/Images/deepfriedX.png" />
<asp:ImageButton runat="server" ImageUrl="~/Images/deepfriedO.png" />--%>

<div>
    <asp:ImageButton runat="server" ID="Square00" OnCommand="Square_Command" CommandArgument="00" ImageUrl="~/Images/deepfriedBlank.png" />
    <asp:ImageButton runat="server" ID="Square01" OnCommand="Square_Command" CommandArgument="01" ImageUrl="~/Images/deepfriedBlank.png" />
    <asp:ImageButton runat="server" ID="Square02" OnCommand="Square_Command" CommandArgument="02" ImageUrl="~/Images/deepfriedBlank.png" />
</div>
<div>
    <asp:ImageButton runat="server" ID="Square10" OnCommand="Square_Command" CommandArgument="10" ImageUrl="~/Images/deepfriedBlank.png" />
    <asp:ImageButton runat="server" ID="Square11" OnCommand="Square_Command" CommandArgument="11" ImageUrl="~/Images/deepfriedBlank.png" />
    <asp:ImageButton runat="server" ID="Square12" OnCommand="Square_Command" CommandArgument="12" ImageUrl="~/Images/deepfriedBlank.png" />
</div>
<div>
    <asp:ImageButton runat="server" ID="Square20" OnCommand="Square_Command" CommandArgument="20" ImageUrl="~/Images/deepfriedBlank.png" />
    <asp:ImageButton runat="server" ID="Square21" OnCommand="Square_Command" CommandArgument="21" ImageUrl="~/Images/deepfriedBlank.png" />
    <asp:ImageButton runat="server" ID="Square22" OnCommand="Square_Command" CommandArgument="22" ImageUrl="~/Images/deepfriedBlank.png" />
</div>
<div>
    <asp:Button runat="server" ID="Reset" OnCommand="Reset_Command" />
</div>