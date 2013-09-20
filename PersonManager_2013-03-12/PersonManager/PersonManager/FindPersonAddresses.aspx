<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FindPersonAddresses.aspx.vb" Inherits="PersonManager.FindPersonAddresses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Find PersonAddresses</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Find Person Addresses</h1>
        <p>
            <asp:LinkButton ID="lnkNewPerson" runat="server">Create New Person Address</asp:LinkButton></p>
        <div style="border: 1px solid black; width: 500px;">
            <table width="99%" cellpadding="5px">
                <%--<tr>
                    <td style="width: 25%">
                        First Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                   
                    
                </tr>
                <tr>
                    <td>
                        Last Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>--%>
                 <tr>
                    <td style="width: 25%">
                        Person 
                        ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPersonID" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                   
                    
                </tr>
                <tr>
                    <td style="width: 25%">
                        Address 
                        ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddressID" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                   
                    
                </tr>

                <tr>
                    <td>
                        Address Type:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddressTypeID" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 25%">
                        Description :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                   
                    
                </tr>
                <tr>
                    <td>
                        Notes:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotes" runat="server" Style="width: 75%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="80px" />&nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:GridView ID="gvPersonAddresses" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            Width="1054px" PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom"
            EmptyDataText="Search returned 0 results">
            <Columns>
                <asp:TemplateField HeaderText="Person ID">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPersonID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address ID">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddressID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AddressTypeID">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddressTypeID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Notes">
                <ItemTemplate>
                        <asp:Label ID="lblNotes" runat="server" Text="Label"></asp:Label>
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
