<%@ Page Title="" Language="C#" MasterPageFile="~/TestMasterPage.master" AutoEventWireup="true" CodeFile="DeletePerson.aspx.cs" Inherits="DeletePerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <asp:TextBox ID="SampleTextBox" runat="server" 
            ontextchanged="SampleTextBox_TextChanged"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" />
    </p>
</asp:Content>

