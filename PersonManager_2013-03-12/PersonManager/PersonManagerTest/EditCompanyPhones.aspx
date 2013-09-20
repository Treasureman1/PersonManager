<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCompanyPhones.aspx.cs" Inherits="PersonManagerTest.EditCompanyPhones" %>

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
        Phone ID :&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtPhID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; CompanyID :&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
        Area Code :&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtAreaCode" runat="server"></asp:TextBox>
        <br />
        <br />
        Phone Number :&nbsp;&nbsp;
        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
        <br />
        <br />
      Extension :&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtExtension" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Phone Type :&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPhoneTypeID" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDescription" runat="server" Height="65px" Width="190px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Notes&nbsp; :&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Height="61px" Width="251px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Height="26px" onclick="btnSave_Click" 
            Text="Save" />
&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="Cancel" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click"  onclientclick="return confirm('Are you sure you want to Delete the record!')" 
            Text="Delete" />
&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" onclick="btnDone_Click" Text="Done" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
