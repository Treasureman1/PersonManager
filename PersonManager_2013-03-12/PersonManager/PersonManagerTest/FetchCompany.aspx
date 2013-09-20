<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchCompany.aspx.cs" Inherits="PersonManagerTest.FetchCompany" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            margin-top: 2px;
        }
        .style2
        {
            width: 342px;
        }
        .style3
        {
            height: 20px;
        }
        .style4
        {
            height: 25px;
        }
        .style5
        {
            width: 258px;
        }
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 397px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
        Company ID :&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    &nbsp;
                    <table class="style6">
                        <tr>
                            <td class="style7">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search Company Keywords :
        <asp:TextBox ID="txtCompanyKeywords" runat="server"></asp:TextBox>
&nbsp; <asp:Button ID="btnSearchCompanyKeywords" runat="server" 
            onclick="btnSearchCompanyKeywords_Click" Text="?" />
                &nbsp;</td>
                            <td>
                                <asp:RadioButton ID="radioSearch" runat="server" Text="Search Site" AutoPostBack="true" GroupName="Search" Checked="true"/>
&nbsp;&nbsp;
                                <asp:RadioButton ID="radioAdvanced" runat="server" Text="Advanced Search" AutoPostBack="true" GroupName="Search" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
&nbsp;
                    <table class="style1">
                        <tr>
                            <td class="style3" colspan="2">
&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <asp:CheckBox ID="cbCompany" runat="server" Text="Company Name" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="cbAreaCode" runat="server" Text="Area Code" />
                            </td>
                            <td>
&nbsp;<asp:CheckBox ID="cbPhone" runat="server" Text="Phone Number" />
&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="cbAddress" runat="server" Text="Address" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="cbZip" runat="server" Text="Zip" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style2">
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Notes :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Height="44px" Width="175px"></asp:TextBox>
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click1" 
            Text="Search" />
&nbsp;&nbsp;
        <asp:Button ID="btnAddCompany" runat="server" onclick="btnAddCompany_Click" 
            Text="Add Company" />
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


      
      <asp:GridView ID="gvCompanyKeywords" runat="server" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvCompanyKeywords_RowDataBound" AllowPaging="true" OnPageIndexChanging="gvCompanyKeywords_PageIndexChanging3"
            OnRowCommand="gvCompanyKeywords_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name">
                    <HeaderStyle Width="30%" />
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
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
        <br />
        <br />
      <asp:GridView ID="gvCompanyName" runat="server" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvCompanyName_RowDataBound" AllowPaging="true" OnPageIndexChanging="gvCompanyName_PageIndexChanging2"
            OnRowCommand="gvCompanyName_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <HeaderStyle Width="30%" />
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
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
