<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPerson.aspx.cs" Inherits="PersonManagerTest.InsertPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="MenuButton" runat="server" PostBackUrl="~/Menu.aspx" 
            Text="Back to Menu" onclick="MenuButton_Click" />
    
        &nbsp;&nbsp;&nbsp;<asp:Button ID="SearchNameButton" runat="server" 
            PostBackUrl="~/FetchPersonName.aspx" Text="Search by Name" 
            onclick="SearchNameButton_Click" />
&nbsp;&nbsp; <asp:Button ID="AddButton" runat="server" 
            onclick="Button1_Click" Text="Add New Person" Visible="False" Width="120px" />
        <br />
        <br />
        &nbsp; ID: 
        <asp:TextBox ID="txtID" runat="server" ReadOnly="True" Width="44px"></asp:TextBox>
        <br />
    
        <br />
&nbsp;&nbsp;&nbsp; First Name:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
        <br />
        <br />
&nbsp;&nbsp;&nbsp; Last Name:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click1" Text="Save" 
            Height="26px" Width="53px" />
        <br />
&nbsp;<asp:Label ID="NameDisplayLabel" runat="server"></asp:Label>
&nbsp;<asp:Label ID="SuccessLabel" runat="server" Text="has been successfully added." 
            Visible="False"></asp:Label>
        <br />
&nbsp;&nbsp;
        <br />
&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        &nbsp;
        &nbsp;
        &nbsp;<br />
        <br />
    
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
