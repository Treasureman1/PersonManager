<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchPersonName.aspx.cs" Inherits="PersonManagerTest.FetchPersonName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Create New Person</asp:LinkButton>
        <br />
        <br />
&nbsp;&nbsp; First Name:
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp; Last Name:&nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFindPerson" runat="server" Text="Find Person" 
            onclick="btnFindPerson_Click" />
        <br />
        <br />
        <asp:GridView ID="gvPersonName" runat="server" AutoGenerateColumns="false" 
            Width="436px"  OnRowDataBound="gvPersonName_RowDataBound" AllowPaging="true" OnPageIndexChanging="gvPersonName_PageIndexChanging2">
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
    
    </div>
    </form>
</body>
</html>
