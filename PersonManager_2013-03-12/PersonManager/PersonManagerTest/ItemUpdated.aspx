<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemUpdated.aspx.cs" Inherits="PersonManagerTest.ItemUpdated" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        ID :
        <asp:TextBox ID="IDTextBox" runat="server" ReadOnly="True" Width="67px"></asp:TextBox>
        <br />
        <br />
        First Name :
        <asp:TextBox ID="FirstNameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        Last Name:&nbsp;&nbsp;
        <asp:TextBox ID="LastNameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
