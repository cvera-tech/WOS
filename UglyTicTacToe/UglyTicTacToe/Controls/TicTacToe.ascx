<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicTacToe.ascx.cs" Inherits="UglyTicTacToe.Controls.TicTacToe" %>

<asp:Image runat="server" ImageUrl="~/Images/deepfriedLogo.png"/>
<asp:Panel runat="server" ID="GameEndPanel">
    <asp:Image runat="server" ID="WinImage" ImageUrl="~/Images/deepfriedWinner.png" />
    <asp:Image runat="server" ID="PlayerImage" />
    <asp:Image runat="server" ID="TieImage" ImageUrl="~/Images/deepfriedTied.png" />
</asp:Panel>

<div>
    <asp:ImageButton runat="server" ID="Square00" OnCommand="Square_Command" CommandArgument="00" />
    <asp:ImageButton runat="server" ID="Square01" OnCommand="Square_Command" CommandArgument="01" />
    <asp:ImageButton runat="server" ID="Square02" OnCommand="Square_Command" CommandArgument="02" />
</div>
<div>
    <asp:ImageButton runat="server" ID="Square10" OnCommand="Square_Command" CommandArgument="10" />
    <asp:ImageButton runat="server" ID="Square11" OnCommand="Square_Command" CommandArgument="11" />
    <asp:ImageButton runat="server" ID="Square12" OnCommand="Square_Command" CommandArgument="12" />
</div>
<div>
    <asp:ImageButton runat="server" ID="Square20" OnCommand="Square_Command" CommandArgument="20" />
    <asp:ImageButton runat="server" ID="Square21" OnCommand="Square_Command" CommandArgument="21" />
    <asp:ImageButton runat="server" ID="Square22" OnCommand="Square_Command" CommandArgument="22" />
</div>
<div>
    <asp:Button runat="server" ID="Reset" OnCommand="Reset_Command" text="Start New Game" />
</div>