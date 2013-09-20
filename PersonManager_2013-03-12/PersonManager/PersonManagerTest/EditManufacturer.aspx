<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditManufacturer.aspx.cs" Inherits="PersonManagerTest.EditManufacturer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Manufacturer ID :&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Notes :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Height="72px" Width="179px"></asp:TextBox>
        <br />
        <br />
&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" />
&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
&nbsp;
        <asp:Button ID="btnDone" runat="server" Text="Done" />
&nbsp;
        <br />
    
    </div>
    </form>
</body>
</html>
