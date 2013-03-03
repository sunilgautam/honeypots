<%@ Page Language="C#" AutoEventWireup="true" CodeFile="like.aspx.cs" Inherits="like" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Like / Unlike</h1>
        <asp:Button ID="Button1" runat="server" Text="Like" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Unlike" onclick="Button2_Click" />
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
