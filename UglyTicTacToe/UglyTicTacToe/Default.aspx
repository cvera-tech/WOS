<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UglyTicTacToe.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Why are you playing this?</title>
    <link href="~/Styles/Awful.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <jwl:TicTacToe runat="server"></jwl:TicTacToe>
    </div>
    </form>
</body>
</html>
