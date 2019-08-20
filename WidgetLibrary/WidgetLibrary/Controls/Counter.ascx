<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Counter.ascx.cs" Inherits="WidgetLibrary.Controls.Counter" %>

<asp:Button ID="DecrementButton" runat="server" Text="-" OnClick="DecrementButton_Click" />
<asp:Label ID="CounterLabel" runat="server" />
<asp:Button ID="IncrementButton" runat="server" Text="+" OnClick="IncrementButton_Click" />