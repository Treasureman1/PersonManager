<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchPersons.aspx.cs" Inherits="PersonManagerTest.FetchPersons" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;Fetch All Person&#39;s<br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Create New Person</asp:LinkButton>
        <br />
        <br />        <%-- AllowPaging="true" OnPageIndexChanging="gvPersonName_PageIndexChanging"          AllowPaging="true" OnPageIndexChanging="GridViewPageEventHandler"--%>
        <asp:GridView ID="gvPersonName" runat="server" AutoGenerateColumns="false" 
            Width="436px" OnRowDataBound="gvPersonName_RowDataBound" 
            AllowPaging="true" OnPageIndexChanging="gvPersonName_PageIndexChanging">
           <%-- onselectedindexchanged="gvPersonName_SelectedIndexChanged"--%>
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
