<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestSQLInject.aspx.cs" Inherits="TestSQLInject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="pnlForm" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Username" style="display: block;"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" style="width: 250px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ErrorMessage="Enter username" ForeColor="Red"></asp:RequiredFieldValidator>

        <asp:Label ID="Label2" runat="server" Text="Password" style="display: block;"></asp:Label>        
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" style="width: 250px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" runat="server" ErrorMessage="Enter password" ForeColor="Red"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="btnSave" runat="server" Text="Submit" onclick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" ValidationGroup="cancel" />
    </asp:Panel>
    <asp:Panel ID="pnlSuccess" runat="server" style="padding: 10px; color: Green; font-weight: bold; position: relative;">
        <asp:Label ID="Label3" runat="server" Text="Success"></asp:Label>
        <asp:Button ID="btnTryAgain1" runat="server" Text="Try Again" ValidationGroup="try" onclick="btnTryAgain_Click" style="position: absolute; right: 5px; top: 5px;" />
    </asp:Panel>
    <asp:Panel ID="pnlFail" runat="server" style="padding: 10px; color: Red; font-weight: bold; position: relative;">
        <asp:Label ID="Label4" runat="server" Text="Fail due to invalid credentials"></asp:Label>
        <asp:Button ID="btnTryAgain2" runat="server" Text="Try Again" ValidationGroup="try" onclick="btnTryAgain_Click" style="position: absolute; right: 5px; top: 5px;" />
    </asp:Panel>
    <asp:Panel ID="pnlInjected" runat="server" style="padding: 10px; color: Red; font-weight: bold; position: relative;">
        <asp:Label ID="Label5" runat="server" Text="Fail due to SQL Injection"></asp:Label>
        <asp:Button ID="btnTryAgain3" runat="server" Text="Try Again" ValidationGroup="try" onclick="btnTryAgain_Click" style="position: absolute; right: 5px; top: 5px;" />
    </asp:Panel>
</asp:Content>