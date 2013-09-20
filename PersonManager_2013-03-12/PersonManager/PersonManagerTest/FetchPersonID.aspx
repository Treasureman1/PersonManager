<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchPersonID.aspx.cs" Inherits="PersonManagerTest.FetchPersonID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Fetch Person ID Page<br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Create New Person</asp:LinkButton>
        <br />
        <br />
        <br />
        Person ID :&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
            Text="Search" />
        <br />
        <br />
        <br />
        \<asp:GridView ID="gvPersonName" runat="server" AutoGenerateColumns="False" 
            Width="436px"  OnRowDataBound="gvPersonName_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPersonID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                <HeaderStyle Width="30%" />
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                <HeaderStyle Width="35%" />
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="25%" />
                     <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View">View</asp:LinkButton>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
