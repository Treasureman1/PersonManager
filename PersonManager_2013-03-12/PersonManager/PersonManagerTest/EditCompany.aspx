<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="PersonManagerTest.EditCompany" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Company ID :&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
        Company Name :&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Notes :&nbsp;
        <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" 
            onclick="btnDelete_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" Text="Done" onclick="btnDone_Click" />
&nbsp;
    
        <br />
        <br />
        <asp:Button ID="btnAddPhoneNum" runat="server" onclick="btnAddPhoneNum_Click" 
            Text="Add Phone Number" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddEmail" runat="server" onclick="btnAddEmail_Click" 
            Text="Add Email" />
&nbsp;&nbsp;
        <asp:Button ID="btnAddAddress" runat="server" onclick="btnAddAddress_Click" 
            Text="Add Address" />
    
    </div>
    <asp:GridView ID="gvCompanyPhoneNumber" runat="server" EmptyDataText="No Record found!" 
            ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvCompanyPhoneNumber_RowDataBound" 
            OnRowCommand="gvCompanyPhoneNumber_RowCommand" Height="168px">
            <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>

            <Columns>
          
                <asp:TemplateField HeaderText="Phone ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Area Code">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblAreaCode" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number">
                    <HeaderStyle Width="30%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneNumber" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Extension">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblExtension" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone Type ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneTypeID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                             
                <asp:TemplateField HeaderText="Action">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View">View</asp:LinkButton>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                     
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    <br />

     <asp:GridView ID="gvCompanyAddresses" runat="server" EmptyDataText="No Record Found!"
            ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvCompanyAddresses_RowDataBound" 
            OnRowCommand="gvCompanyAddresses_RowCommand" Height="168px">
            <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>

      <%--  <emptydatatemplate>

          <asp:image id="NoDataImage"
            imageurl="~/images/noRecord.gif"
            alternatetext="No Image" 
            runat="server"/>

            No Data Found.  

        </emptydatatemplate>--%> 

            <Columns>
              
           <%-- <asp:TemplateField HeaderText="Person ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPersonID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Address ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddressID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Street 1">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblStreet1" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Street 2">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblStreet2" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="City">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="State">
                    <HeaderStyle Width="5%" />
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Zip">
                    <HeaderStyle Width="5%" />
                    <ItemTemplate>
                        <asp:Label ID="lblZip" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                             
                <asp:TemplateField HeaderText="Action">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View">View</asp:LinkButton>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                     
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    <br />
  
        <asp:GridView ID="gvCompanyContacts" runat="server" EmptyDataText="No Record Found"
            ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvCompanyContacts_RowDataBound" 
            OnRowCommand="gvCompanyContacts_RowCommand" Height="168px">
           <%-- <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>

        <emptydatatemplate>

          <asp:image id="NoDataImage"
            imageurl="~/images/noRecord.gif"
            alternatetext="No Image" 
            runat="server"/>

            No Data Found.  

        </emptydatatemplate> --%>

            <Columns>
              
           <%-- <asp:TemplateField HeaderText="Person ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPersonID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Company ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact ID">
                    <HeaderStyle Width="30%" />
                    <ItemTemplate>
                        <asp:Label ID="lblContactID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Notes">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblNotes" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                          
                <asp:TemplateField HeaderText="Action">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View">View</asp:LinkButton>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                     
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
