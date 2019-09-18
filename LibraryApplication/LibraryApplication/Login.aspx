<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login</h1>
        <div>
            <asp:Label ID="BadLoginMessage" runat="server"
                ForeColor="Red"
                Text="Invalid user name or password."
                Visible="false" />
        </div>
        <fieldset>
            <asp:ValidationSummary runat="server" 
                ValidationGroup="Login" />
            <uc:TextBox ID="UserNameTextBox" runat="server"
                Label="User Name: "
                Required="true"
                RequiredErrorMessage="User name required."
                ValidationGroup="Login" />
            <uc:TextBox ID="PasswordTextBox" runat="server"
                Label="Password: "
                TextMode="Password"
                Required="true"
                RequiredErrorMessage="Password required."
                ValidationGroup="Login" />
            <div>
                <asp:Button ID="SubmitButton" runat="server" 
                    OnCommand="SubmitButton_Command"
                    Text="Submit" 
                    ValidationGroup="Login" />
            </div>
        </fieldset>
    </form>
</body>
</html>
