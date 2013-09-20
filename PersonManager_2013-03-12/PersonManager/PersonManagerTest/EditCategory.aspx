<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="PersonManagerTest.EditCategory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Category ID :&nbsp;&nbsp;
        <asp:TextBox ID="txtCID" runat="server"></asp:TextBox>
        <br />
        <br />
        Category Name :
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Description :&nbsp;
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="Cancel" />
&nbsp;
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            Text="Delete" />
&nbsp;
        <asp:Button ID="btnDone" runat="server" onclick="btnDone_Click" Text="Done" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
