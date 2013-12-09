<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomLogin.aspx.cs" Inherits="Infrastructure.Account.CustomLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>User ID</td>
            <td><asp:TextBox ID="userIdTextBox" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    
</asp:Content>
