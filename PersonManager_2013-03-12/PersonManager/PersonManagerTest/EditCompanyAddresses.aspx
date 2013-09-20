<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCompanyAddresses.aspx.cs" Inherits="PersonManagerTest.EditCompanyAddresses" %>

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
        Company ID :&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Address ID:&nbsp;
        <asp:TextBox ID="txtAID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Address Type :&nbsp;
        <asp:DropDownList ID="ddlAddressTypeID" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Company Name :&nbsp;&nbsp;
        <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
        <br />
        <br />
        Street 1 :&nbsp;&nbsp;
        <asp:TextBox ID="txtStreet1" runat="server" Width="393px"></asp:TextBox>
        <br />
        <br />
        Street 2 :&nbsp;
        <asp:TextBox ID="txtStreet2" runat="server" Width="400px"></asp:TextBox>
        <br />
        <br />
        City :&nbsp;
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
&nbsp;&nbsp; State :&nbsp;&nbsp;
        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
&nbsp;&nbsp; Zip :&nbsp;
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        Description :&nbsp;
        <asp:TextBox ID="txtDescription" runat="server" Height="69px" Width="208px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Notes :&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Height="66px" Width="241px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;
        <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="Cancel" />
&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" onclientclick="return confirm('Are you sure you want to Delete the record!')" 
            Text="Delete" />
&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" onclick="btnDone_Click" Text="Done" />
&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
        <br />
    
    </div>
    </form>
</body>
</html>
