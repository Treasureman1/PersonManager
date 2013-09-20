<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Test.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 96%;
        }
        .style4
        {
            width: 462px;
        }
        .style5
        {
            width: 1px;
        }
        .style6
        {
            width: 99px;
        }
        .style7
        {
            width: 150px;
        }
        .style8
        {
            width: 91px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        
            <div id="divGeneralInformation">
            <h2> General Information&nbsp;&nbsp;&nbsp;&nbsp; </h2>
        <table class="style1">
            <tr>
                <td class="style8">
                    ID</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="txtID" runat="server" ReadOnly="True" Width="28px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table class="style1">
            <tr>
                <td class="style6">
                    Title</td>
                <td class="style7">
                    <asp:TextBox ID="txtTitle" runat="server" Width="139px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    First Name</td>
                <td class="style7">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="141px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Last Name</td>
                <td class="style7">
                    <asp:TextBox ID="txtLastName" runat="server" Width="142px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click" Text="Edit" />
&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
        <br /></div>
       <%-- <h2>
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LinkButton</asp:LinkButton>
        </h2>--%>
        <div id="divAddresses">
        <h2>Addresses</h2>
        <p>
            <asp:Literal ID="LitAddressesTable" runat="server"></asp:Literal>
&nbsp;<asp:PlaceHolder ID="phAddressTable" runat="server"></asp:PlaceHolder>
        </p>
        <p>
            <asp:Button ID="btnAddress" runat="server" Text="Add New" 
                onclick="btnAddress_Click" />
        </p></div>
        <div id="divTelephoneNumbers">
        <h2>Telephone Numbers</h2>
        <p>
            <asp:Literal ID="litPhoneTable" runat="server"></asp:Literal>
&nbsp;
            <asp:PlaceHolder ID="phTelephoneTable" runat="server"></asp:PlaceHolder>

            <asp:Label ID="lblPhoneTable" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnPhone" runat="server" Text="Add New" 
                onclick="btnPhone_Click" />
        </p></div>
        <div id="divEmailAddresses"></div>
        <h2>Email Addresses</h2>
            <p>&nbsp;</p>
        <p>
            <asp:Literal ID="litEmailTable" runat="server"></asp:Literal>

            <asp:PlaceHolder ID="phEmailAddressTable" runat="server"></asp:PlaceHolder>
&nbsp;<asp:Label ID="lblEmailTable" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnEmail" runat="server" Text="Add New" 
                onclick="btnEmail_Click" />
        </p>
        <p>
            &nbsp;</p>
        <br />
&nbsp;&nbsp;

        <%-- <asp:Button ID="btnTest2" runat="server" onclick="btnTest2_Click" 
            Text="Display Table" />--%>
        <br />
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <br />
    
    </form>
</body>
</html>
