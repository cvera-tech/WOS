<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LibraryApplication.Pages.Account.ChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <fieldset>
        <asp:Panel ID="IncorrectPasswordPanel" runat="server" Visible="false">
            <asp:Label runat="server" ForeColor="Red" Text="Incorrect password." />
        </asp:Panel>
        <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
            <asp:Label runat="server" ForeColor="Green" Text="Password successfully changed." />
        </asp:Panel>
        <asp:ValidationSummary runat="server"
            ValidationGroup="ChangePassword" />
        <uc:TextBox ID="OldPassword" runat="server"
            Label="Current password: "
            TextMode="Password"
            Required="true"
            RequiredErrorMessage="Current password required."
            ValidationGroup="ChangePassword" />
        <uc:TextBox ID="NewPassword" runat="server"
            Label="New password: "
            TextMode="Password"
            Required="true"
            RequiredErrorMessage="New password required."
            ValidationGroup="ChangePassword" />
        <div>
            <asp:Button ID="SubmitButton" runat="server"
                Text="Submit"
                OnCommand="SubmitButton_Command"
                ValidationGroup="ChangePassword" />
            <asp:Button ID="CancelButton" runat="server"
                Text="Cancel"
                OnCommand="CancelButton_Command" />
        </div>
    </fieldset>

</asp:Content>
