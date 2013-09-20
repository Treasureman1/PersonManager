<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="PersonManagerTest.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;
        <br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SubmitButton" runat="server" onclick="SubmitButton_Click" 
            style="height: 26px; width: 61px" Text="Submit" />
&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Width="239px"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
