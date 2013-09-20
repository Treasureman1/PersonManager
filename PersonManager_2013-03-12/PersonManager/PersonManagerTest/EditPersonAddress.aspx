<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPersonAddress.aspx.cs" Inherits="PersonManagerTest.EditPersonAddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblModeStatus" runat="server" Font-Size="Medium"></asp:Label>
        <br />
        <br />
    
        Person ID :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server" Width="61px"></asp:TextBox>
&nbsp; Address ID :&nbsp;
        <asp:TextBox ID="txtAID" runat="server" Width="68px" Height="22px"></asp:TextBox>
&nbsp;Address Type&nbsp;
        <asp:DropDownList ID="ddlAddressTypeID" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Full Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        <br />
        <br />
        Street 1 :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStreet1" runat="server" Width="342px"></asp:TextBox>
        <br />
        <br />
        Street 2 :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStreet2" runat="server" Width="343px"></asp:TextBox>
        <br />
        <br />
        City :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCity" runat="server" Width="114px"></asp:TextBox>
&nbsp;&nbsp; State :&nbsp;
        <asp:TextBox ID="txtState" runat="server" Width="42px"></asp:TextBox>
&nbsp;&nbsp; Zip:
        <asp:TextBox ID="txtZip" runat="server" Width="76px"></asp:TextBox>
        <br />
        <br />
        Description :&nbsp;&nbsp;
        <asp:TextBox ID="txtDescription" runat="server" Height="60px" Width="171px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Notes :&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Height="59px" Width="171px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click1" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" 
            onclientclick="return confirm('Are you sure you want to Delete the record!')" 
            onclick="btnDelete_Click1" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" Text="Done" onclick="btnDone_Click1" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="55px" 
            onclick="btnSave_Click1" />
        <br />
        <br />
        cancel delete save done add address<br />
        <br />
    
    </div>
    </form>
</body>
</html>
