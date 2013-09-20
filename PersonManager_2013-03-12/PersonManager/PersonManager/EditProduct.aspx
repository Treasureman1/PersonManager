<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditProduct.aspx.vb" Inherits="PersonManager_EditProduct" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Person</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Edit Product</h1>
        <div style="border: 1px solid black; width: 500px;">
            <table width="99%" cellpadding="5px">
                <tr>
                    <td style="width: 25%">
                        ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPersonID" runat="server" Style="width: 10%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%">
                        First Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="80px" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
