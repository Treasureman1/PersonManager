<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressForm.aspx.cs" Inherits="Test.AddressForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 34%;
            height: 313px;
        }
        .style2
        {
            width: 273px;
        }
        .style3
        {
            width: 158px;
        }
        .style4
        {
            width: 34%;
        }
        .style5
        {
            width: 215px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />Person ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtID" runat="server" Width="25px" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br /></div>
        <table class="style1">
            <tr>
                <td class="style2">
                    Address Type ID</td>
                <td class="style3">
                    <asp:TextBox ID="txtATID" runat="server" Width="25px"></asp:TextBox>
                &nbsp;
                    <asp:DropDownList ID="ddlAddressTypeID" runat="server" Visible="False" 
                        Height="16px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label>
&nbsp;&nbsp;
                    <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Address ID:</td>
                <td class="style3">
                    <asp:TextBox ID="txtAID" runat="server" Height="22px" Width="25px" 
                        ReadOnly="True"></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Street 1:</td>
                <td class="style3">
                    <asp:TextBox ID="txtStreet1" runat="server" Width="128px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Street 2:</td>
                <td class="style3">
                    <asp:TextBox ID="txtStreet2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    City:</td>
                <td class="style3">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    State:</td>
                <td class="style3">
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Zip:</td>
                <td class="style3">
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Notes:</td>
                <td class="style3">
                    <asp:TextBox ID="txtNotes" runat="server" Height="50px" Width="136px"></asp:TextBox>
                </td>
            </tr>
        </table>
    <table class="style4">
        <tr>
            <td class="style5">
                Description:</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="58px" Width="132px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        onclick="btnCancel_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                       OnClientClick="return confirm('Are you sure you want to Delete the record?');"  Text="Delete" />
                </td>
            <td>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                        Width="52px" Height="24px" />
                </td>
        </tr>
    </table>
    &nbsp;&nbsp;
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </body>
</html>
