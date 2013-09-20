<%@ Page Title="" Language="C#" MasterPageFile="~/TestMasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/FetchPersons.aspx">Fetch Persons</asp:HyperLink>
</p>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/FetchPersonID.aspx">Fetch Person by ID</asp:HyperLink>
</p>
    <p>
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/FetchPersonName.aspx">Fetch Person by Name</asp:HyperLink>
</p>
    <p>
        <asp:LinkButton ID="InsertPersonLink" runat="server" 
            onclick="InsertPersonLink_Click">Insert Person</asp:LinkButton>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

