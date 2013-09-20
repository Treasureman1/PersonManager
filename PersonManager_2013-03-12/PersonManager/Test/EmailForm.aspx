<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailForm.aspx.cs" Inherits="Test.EmailForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblEmailForm" runat="server" Font-Size="X-Large" 
            Text="Email Address Form"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
&nbsp;
        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblPersonID" runat="server" Text="Person ID" Visible="False"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server" ReadOnly="True" 
            style="margin-bottom: 0px" Width="30px"></asp:TextBox>
        <br />
        <br />
        Email Address ID:&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtEAID" runat="server" ReadOnly="True" Width="37px"></asp:TextBox>
        <br />
        <br />
        Email:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAddress" runat="server" Width="118px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Cancel" onclick="Button1_Click" />
&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
        &nbsp;
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
           OnClientClick="return confirm('Are you sure you want to Delete the record?');"  Text="Delete" />
        <br />
    
    </div>
    </form>
</body>
</html>
