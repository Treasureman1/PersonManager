<%@ Page Title="" Language="C#" MasterPageFile="~/TestMasterPage.master" AutoEventWireup="true" CodeFile="EditPersonTest.aspx.cs" Inherits="EditPersonTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
        Edit Person</h1>
            <table width="99%" cellpadding="5px" 
        style="width: 49%; height: 221px">
                <tr>
                    <td style="width: 25%">
                        ID:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPersonID" runat="server" Style="width: 10%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
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
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnDone" runat="server" Text="Done" Width="80px" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" 
                            onclick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="80px" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
                    </td>
                </tr>
            </table>
        </asp:Content>

