<%@ Page Title="" Language="C#" MasterPageFile="~/TestMasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Fetch Person&#39;s&nbsp;</p>
    <p>
        Fetch Person by ID</p>
    <p>
        Fetch Person by Name</p>
    <p>
        <asp:LinkButton ID="InsertPersonLink" runat="server" 
            onclick="InsertPersonLink_Click">Insert Person</asp:LinkButton>
    </p>
    <p>
        Update Person</p>
    <p>
        Delete Person</p>
    <p>
        &nbsp;</p>
</asp:Content>

