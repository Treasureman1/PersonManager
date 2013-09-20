<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="PersonManagerTest.EditProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 89%;
        }
        .style4
        {
        }
        .style5
        {
            width: 283px;
        }
        .style6
        {
            width: 312px;
        }
        .style7
        {
            width: 175px;
        }
        .style8
        {
            width: 178px;
        }
        .style9
        {
            width: 100%;
        }
        .style10
        {
            width: 196px;
        }
        .style11
        {
            width: 145px;
        }
        .style12
        {
            width: 137px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table class="style9">
            <tr>
                <td class="style10">
                    Product ID :&nbsp; 
                    <asp:TextBox ID="txtPID" runat="server" Width="96px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style11">
                    Category ID :&nbsp; 
                    <asp:TextBox ID="txtCID" runat="server" Width="41px"></asp:TextBox>
                </td>
                <td class="style12">
                    Supplier ID :&nbsp;
                    <asp:TextBox ID="txtSID" runat="server" Width="38px"></asp:TextBox>
                </td>
                <td>
                   Manufacturer ID:
                    <asp:TextBox ID="txtMID" runat="server" Width="43px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        Model Number :&nbsp;&nbsp;      
        <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
        <br />
        <br />
        Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Description :
        <asp:TextBox ID="txtDescription" runat="server" Width="474px"></asp:TextBox>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style6">
                    Serial Number :&nbsp;
                    <asp:TextBox ID="txtSN" runat="server" Width="182px"></asp:TextBox>
                </td>
                <td class="style5">
             UPC :&nbsp;
                    <asp:TextBox ID="txtUPC" runat="server" Width="187px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <table class="style1">
            <tr>
                <td class="style7">
                    Units In Stock :&nbsp;
                    <asp:TextBox ID="txtInStock" runat="server" Width="54px"></asp:TextBox>
                </td>
                <td class="style8">
                    Units On Order :&nbsp;
                    <asp:TextBox ID="txtOnOrder" runat="server" Width="43px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;Reorder Level :&nbsp;
                    <asp:TextBox ID="txtReorder" runat="server"></asp:TextBox>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
&nbsp;&nbsp; Discontinued Notes :&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Height="49px" Width="180px"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" Text="Done" />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
