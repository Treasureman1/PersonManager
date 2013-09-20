<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelephoneForm.aspx.cs" Inherits="Test.TelephoneForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 138px;
        }
        .style3
        {
            width: 317px;
        }
        .style4
        {
            width: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblTelephoneForm" runat="server" Font-Size="X-Large" 
            Text="Telephone Form"></asp:Label>
        <br />
        <br />
        Person ID&nbsp;&nbsp;
        <asp:Label ID="lblID" runat="server" Text="ID Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server" Height="22px" ReadOnly="True" 
            Visible="False" Width="25px"></asp:TextBox>
        &nbsp;<br />
        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
&nbsp;
        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Phone ID&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPHID" runat="server" Width="24px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Area Code
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtAreaCode" runat="server" Height="22px" Width="25px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Phone Number&nbsp;
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Extension&nbsp;
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtExtension" runat="server" Width="25px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbDNC" runat="server" Text="Do Not Call" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    PhoneTypeID 
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPHTID" runat="server" Width="25px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlPhoneTypeID" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style4">
                   &nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbDNT" runat="server" Text="Do Not Text" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    Description&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:TextBox ID="txtDescription" runat="server" Height="51px" Width="204px"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    Notes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtNotes" runat="server" Height="52px" Width="227px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
        &nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete the record?');" />

            <%-- <asp:Button ID="Button1" runat="server" Style="z-index: 101; left: 216px; position: absolute;
           top: 160px" Text="Button" OnClientClick="return confirm('change a record, would you like to continue ?');" />
--%>
        <br />
    
    </div>
    </form>
</body>
</html>
