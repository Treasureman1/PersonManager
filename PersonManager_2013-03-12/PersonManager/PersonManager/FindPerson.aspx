<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FindPerson.aspx.vb" Inherits="PersonManager.FindPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Find Person</title>
    <style type="text/css">
        .style1
        {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Find Person</h1>
        <p>
            <asp:LinkButton ID="lnkNewPerson" runat="server">Create New Person</asp:LinkButton></p>
        <div style="border: 1px solid black; width: 500px;">
            <table width="99%" cellpadding="5px">
                <tr>
                    <td style="width: 25%">
                        First Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Last Name:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtLastName" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="80px" 
                            Height="26px" />&nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:GridView ID="gvPersons" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            Width="502px" PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom"
            EmptyDataText="Search returned 0 results">
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
            <PagerSettings Mode="NumericFirstLast"></PagerSettings>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
