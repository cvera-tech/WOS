<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotAuthorized.aspx.cs" Inherits="LibraryApplication.NotAuthorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>NOT AUTHORIZED</h1>
        <asp:Button ID="SwitchButton" runat="server" OnCommand="SwitchButton_Command" Text="Switch Account" />
        <asp:Button ID="HomeButton" runat="server" OnCommand="HomeButton_Command" Text="Back to Homepage" />
    </div>
    </form>
</body>
</html>
