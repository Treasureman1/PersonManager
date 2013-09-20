<%@ Page Title="" Language="C#" MasterPageFile="~/TestMasterPage.master" AutoEventWireup="true" CodeFile="InsertPerson.aspx.cs" Inherits="InsertPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        first Name:
    </p>
    <p>
        Last Name
    </p>
    <p>
        Save btn&nbsp;&nbsp; and cancel button which takes you back to the menu page.
    </p>
    <p>
        if we click the save button it will take the value in the first and last name 
        boxes and uses them as a parameter for the insert function .
    </p>
    <p>
        when finished inserting record, direct the user to menu page.
        <br />
    </p>
    <p>
    </p>
</asp:Content>

