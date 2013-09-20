<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchPerson.aspx.cs" Inherits="PersonManagerTest.FetchPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        &nbsp;ID:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Search Person Keyords :&nbsp;&nbsp;
        <asp:TextBox ID="txtPersonKeywords" runat="server" Width="142px"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearchPersonKeywords" runat="server" 
            onclick="btnSearchPersonKeywords_Click" Text="?" Width="24px" 
            style="height: 26px" />
        &nbsp;<asp:RadioButton ID="radioSearch" runat="server" AutoPostBack="True" 
            Checked="True" GroupName="Search" Text="Search Site" />
        <asp:RadioButton ID="radioAdvanced" runat="server" AutoPostBack="True" 
            GroupName="Search" Text="Advanced Search" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="cbName" runat="server" Text="Name" />
        <asp:CheckBox ID="cbAreaCode" runat="server" Text="Area Code" />
        <asp:CheckBox ID="cbPhoneNumber" runat="server" Text="Phone Number" />
        <asp:CheckBox ID="cbAddress" runat="server" Text="Address" />
        <asp:CheckBox ID="cbZip" runat="server" Text="Zip" />
        <asp:CheckBox ID="cbEmail" runat="server" Text="Email" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        First Name:&nbsp;&nbsp;
        <asp:TextBox ID="txtFirstName" runat="server" Height="22px"></asp:TextBox>
        <br />
        <br />
        Last Name:&nbsp;&nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" 
            Text="Search" style="height: 26px" />
        &nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Person" />
        <br />
        <br />
        <br />
        <asp:GridView ID="gvPersonName" runat="server" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvPersonName_RowDataBound" AllowPaging="true" OnPageIndexChanging="gvPersonName_PageIndexChanging2"
            OnRowCommand="gvPersonName_RowCommand">
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
    </div>
    </form>
</body>
</html>



