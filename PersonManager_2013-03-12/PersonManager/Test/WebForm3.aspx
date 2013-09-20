<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Test.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" 
            style="margin-bottom: 0px" Text="Show Addresses" />
&nbsp;
        <asp:Button ID="btnLabelTable" runat="server" onclick="Button1_Click" 
            Text="Label Table" />
&nbsp;&nbsp;
        <asp:Button ID="btnLiteralTable" runat="server" onclick="btnLiteralTable_Click" 
            Text="Literal Table " />
&nbsp;&nbsp;
        <asp:Button ID="btnRowTable" runat="server" onclick="btnRowTable_Click" 
            Text="Row Table" />
    
    </div>
    </form>
</body>
</html>
