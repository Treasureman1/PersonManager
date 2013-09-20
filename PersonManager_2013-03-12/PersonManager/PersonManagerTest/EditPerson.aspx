<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPerson.aspx.cs" Inherits="PersonManagerTest.EditPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        ID:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server" Width="42px" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        First Name:&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" onclick="CancelButton_Click" 
            Text="Cancel Button" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
       
       <%-- The Tutorial Explaining this javascript was found at link : http://www.youtube.com/watch?v=cBHiC4Ajb5E--%><%--<span onclick="return confirm('Are you sure you want to Delete the record!')">
           </span>--%>
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" onclientclick="return confirm('Are you sure you want to Delete the record!')"
            Text="Delete" Width="100px" />          
         
        <br />
        <br />
       Last Name:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
            Text="Save" Width="124px" style="margin-bottom: 0px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDone" runat="server" onclick="btnDone_Click" Text="Done" 
            Width="97px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="NameDisplayLabel" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddPhoneNum" runat="server" onclick="btnAddPhoneNum_Click" 
            Text="Add Phone Number" Width="183px" />
        &nbsp;&nbsp;
        <asp:Button ID="btnAddAddress" runat="server" onclick="btnAddAddress_Click" 
            Text="Add Address" />
        &nbsp;&nbsp;
        <asp:Button ID="btnAddEmail" runat="server" onclick="btnAddEmail_Click" 
            Text="Add Email" Width="103px" />
        <br />
        <br />
        <asp:Button ID="btnFillAddress" runat="server" onclick="btnFillAddress_Click" 
            Text="Fill Address Grid" />
        &nbsp;
        <asp:Button ID="btnFillEmail" runat="server" onclick="btnFillEmail_Click" 
            Text="Fill Email Grid" />
        <br />                                <%-- OnPageIndexChanging="gvPersonPhoneNumber_PageIndexChanging2"  AllowPaging="true"--%>
        <br />
        <asp:GridView ID="gvPersonPhoneNumber" runat="server" EmptyDataText="No Record found!" 
            ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvPersonPhoneNumber_RowDataBound" 
            OnRowCommand="gvPersonPhoneNumber_RowCommand" Height="168px">
            <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>

       <%-- <emptydatatemplate>

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
                <asp:TemplateField HeaderText="Phone ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Area Code">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblAreaCode" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number">
                    <HeaderStyle Width="40%" />
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



        <asp:GridView ID="gvPersonAddresses" runat="server" EmptyDataText="No Record found!"
            ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvPersonAddresses_RowDataBound" 
            OnRowCommand="gvPersonAddresses_RowCommand" Height="168px">
            <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>

      <%--  <emptydatatemplate>

          <asp:image id="NoDataImage"
            imageurl="~/images/noRecord.gif"
            alternatetext="No Image" 
            runat="server"/>

            No Data Found.  

        </emptydatatemplate> 
--%>
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
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="State">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Zip">
                    <HeaderStyle Width="10%" />
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
     
        <br />
       <asp:GridView ID="gvEmail" runat="server" EmptyDataText="No Record found!" 
            ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="436px"
            OnRowDataBound="gvEmail_RowDataBound" 
            OnRowCommand="gvEmail_RowCommand" Height="168px">
            <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>


            <Columns>
              
        
                <asp:TemplateField HeaderText="Email Address ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblEmailAddressID" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <HeaderStyle Width="55%" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Person ID">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPersonID" runat="server" Text="Label"></asp:Label>
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