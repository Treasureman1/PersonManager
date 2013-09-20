<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmail.aspx.cs" Inherits="PersonManagerTest.EditEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblModeStatus" runat="server"></asp:Label>
        <br />
        <br />
        Email Address ID : 
        <asp:TextBox ID="txtEID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Person ID :
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
       Email :&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="Cancel" />
&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click"  onclientclick="return confirm('Are you sure you want to Delete the record!')" 
            Text="Delete" />
&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" onclick="btnDone_Click" Text="Done" />
&nbsp;&nbsp;
        <br />
    
    </div>
    </form>
</body>
</html>
