<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditPersonAddresses.aspx.vb" Inherits="PersonManager.EditPersonAddresses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Person Addresses</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Edit Person 
            Addresses</h1>
        <div style="border: 1px solid black; width: 500px;">
            <table width="99%" cellpadding="5px">
                <%--<tr>
                    <td style="width: 25%">
                        First Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"  Style="width: 75%"></asp:TextBox>
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
                --%> 
                <tr>
                   <td>
                        Person ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPersonID" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 25%">
                        Address:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddressID" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                   
                    
                </tr>
                <tr>
                    <td>
                        Address Type:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddressTypeID" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 25%">
                        Description :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                   
                    
                </tr>
                <tr>
                    <td>
                        Notes:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotes" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnDone" runat="server" Text="Done" Width="80px" />
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