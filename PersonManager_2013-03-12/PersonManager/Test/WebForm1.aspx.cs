using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Data;
using System.Web.UI.HtmlControls;
 
namespace Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              if (Request.QueryString["PersonID"] != null)
                {
                    int PersonID = Convert.ToInt32(Request.QueryString["PersonID"]);
                    BusinessObjects.Person person = new BusinessObjects.Person(PersonID);
                    txtID.Text = person.ID.ToString();
                    txtTitle.Text = person.Title;
                    txtFirstName.Text = person.FirstName;
                    txtLastName.Text = person.LastName;
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    btnSave.Visible = false;
                }

                else
                {
                    BusinessObjects.Person person = new BusinessObjects.Person(1);
                }

                if (Request.QueryString["PersonID"] == null)
                {
                    BusinessObjects.Person person = new BusinessObjects.Person(1);
                    txtID.Text = person.ID.ToString();
                    txtTitle.Text = person.Title;
                    txtFirstName.Text = person.FirstName;
                    txtLastName.Text = person.LastName;
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                }                       
        }

            fillPersonAddresses();
            fillPersonPhones();
            fillEmailAddresses();

        }

        private void FillGrid(Person Person)
        {
            //DataSet ds = new DataSet();
            //DataPortal.PersonAddressesData pads = new DataPortal.PersonAddressesData();
            //ds = pads.Fetch(1);
            //gvWebForm.DataSource = ds;
            //gvWebForm.DataBind();
           
        }
        
        private void loadAddresses(Person person)
        {

        }

        private void loadPhones(Person person)
        {
            //Work on the loadPhones function
            //BusinessObjects.Person person1 = new Person(1);
            //person = person1;
            person = new Person(1);
            if (person.Phones.Count > 0)
            {
                System.Web.UI.HtmlControls.HtmlTable phoneTable = new System.Web.UI.HtmlControls.HtmlTable();
                phoneTable.Border = 1;
                phoneTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell phoneIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell areaCodeHeaderTableCell = new HtmlTableCell();
                HtmlTableCell phoneNumberHeaderTableCell = new HtmlTableCell();
                HtmlTableCell extensionHeaderTableCell = new HtmlTableCell();
                HtmlTableCell phoneTypeIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell phoneActionHeaderTableCell = new HtmlTableCell();

                phoneIDHeaderTableCell.InnerText = "Phone ID";
                areaCodeHeaderTableCell.InnerText = "Area Code";
                phoneNumberHeaderTableCell.InnerText = "Phone Number";
                extensionHeaderTableCell.InnerText = "Extension";
                phoneTypeIDHeaderTableCell.InnerText = "Phone Type ID";
                phoneActionHeaderTableCell.InnerText = "Action";

                headerTableRow.Cells.Add(phoneIDHeaderTableCell);
                headerTableRow.Cells.Add(areaCodeHeaderTableCell);
                headerTableRow.Cells.Add(phoneNumberHeaderTableCell);
                headerTableRow.Cells.Add(extensionHeaderTableCell);
                headerTableRow.Cells.Add(phoneTypeIDHeaderTableCell);
                headerTableRow.Cells.Add(phoneActionHeaderTableCell);

                phoneTable.Rows.Add(headerTableRow);

                foreach (BusinessObjects.Phone phone in person.Phones)
                {
                    HtmlTableRow phoneTableRow = new HtmlTableRow();
                    HtmlTableCell phoneIDTableCell = new HtmlTableCell();
                    HtmlTableCell areaCodeTableCell = new HtmlTableCell();
                    HtmlTableCell phoneNumberTableCell = new HtmlTableCell();
                    HtmlTableCell extensionTableCell = new HtmlTableCell();
                    HtmlTableCell phoneTypeIDTableCell = new HtmlTableCell();
                    HtmlTableCell phoneActionTableCell = new HtmlTableCell();

                    phoneIDTableCell.InnerText = phone.PhoneID.ToString(); //some time wrap in some control, JQuery
                    areaCodeTableCell.InnerText = phone.AreaCode.ToString();
                    phoneNumberTableCell.InnerText = phone.PhoneNumber.ToString();
                    extensionTableCell.InnerText = phone.Extension.ToString();
                    phoneTypeIDTableCell.InnerText = phone.PhoneTypeID.ToString();

                    int x = person.ID;
                    int y = phone.PhoneID;
                    LiteralControl litEdit = new LiteralControl();

                    phoneTableRow.Cells.Add(phoneIDTableCell);
                    phoneTableRow.Cells.Add(areaCodeTableCell);
                    phoneTableRow.Cells.Add(phoneNumberTableCell);
                    phoneTableRow.Cells.Add(extensionTableCell);
                    phoneTableRow.Cells.Add(phoneTypeIDTableCell);
                    phoneTableRow.Cells.Add(phoneActionTableCell);
                    phoneTable.Rows.Add(phoneTableRow);

                }
       
               phTelephoneTable.Controls.Add(phoneTable);

            }

            if (person.Phones.Count == 0)
            {
                System.Web.UI.HtmlControls.HtmlTable phoneTable = new System.Web.UI.HtmlControls.HtmlTable();
                phoneTable.Border = 1;
                phoneTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell messageTableCell = new HtmlTableCell();

                messageTableCell.InnerText = "Sorry there are no results.";

                headerTableRow.Cells.Add(messageTableCell);

                phoneTable.Rows.Add(headerTableRow);

                phTelephoneTable.Controls.Add(phoneTable);
                
            }
                
        }

        private void loadEmailAddresses(Person person)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnEdit.Visible = false;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String Title = txtTitle.Text;
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;           
            btnEdit.Visible = true;
            //DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet ds = new DataSet();
         //////   DataPortal.PersonData pd = new DataPortal.PersonData();

            BusinessObjects.Person person = new BusinessObjects.Person();
            person.id = Convert.ToInt32(txtID.Text);
            person.Title = txtTitle.Text;
            person.FirstName = txtFirstName.Text;
            person.LastName = txtLastName.Text;

            person.Save();

        ////////    int PersonID = Convert.ToInt32(txtID.Text);
         /////   pd.UpdatePerson(PersonID, Title, FirstName, LastName);


            
               btnSave.Visible = false;
               btnEdit.Visible = true;
               txtFirstName.Enabled = false;
               txtLastName.Enabled = false;

        }

        #region "Fill Addresses"
        private void fillPersonAddresses()
        {
             BusinessObjects.Person person = new BusinessObjects.Person(1);
                  if (person.Addresses.Count > 0)
            {
                System.Web.UI.HtmlControls.HtmlTable addressTable = new System.Web.UI.HtmlControls.HtmlTable();
                addressTable.Border = 1;
                addressTable.CellPadding = 3; //properties on rows and cells


                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell addressIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell street1HeaderTableCell = new HtmlTableCell();
                HtmlTableCell street2HeaderTableCell = new HtmlTableCell();
                HtmlTableCell cityHeaderTableCell = new HtmlTableCell();
                HtmlTableCell stateHeaderTableCell = new HtmlTableCell();
                HtmlTableCell zipHeaderTableCell = new HtmlTableCell();
                HtmlTableCell addressActionHeaderTableCell = new HtmlTableCell();

                addressIDHeaderTableCell.InnerText = "AddressID";
                street1HeaderTableCell.InnerText = "Street 1";
                street2HeaderTableCell.InnerText = "Street 2";
                cityHeaderTableCell.InnerText = "City";
                stateHeaderTableCell.InnerText = "State";
                zipHeaderTableCell.InnerText = "Zip";
                addressActionHeaderTableCell.InnerText = "Action";

                headerTableRow.Cells.Add(addressIDHeaderTableCell);
                headerTableRow.Cells.Add(street1HeaderTableCell);
                headerTableRow.Cells.Add(street2HeaderTableCell);
                headerTableRow.Cells.Add(cityHeaderTableCell);
                headerTableRow.Cells.Add(stateHeaderTableCell);
                headerTableRow.Cells.Add(zipHeaderTableCell);
                headerTableRow.Cells.Add(addressActionHeaderTableCell);

                addressTable.Rows.Add(headerTableRow);

                foreach (BusinessObjects.PersonAddress personAddress in person.Addresses)
                {
                    HtmlTableRow addressTableRow = new HtmlTableRow();
                    HtmlTableCell addressIDTableCell = new HtmlTableCell();
                    HtmlTableCell street1TableCell = new HtmlTableCell();
                    HtmlTableCell street2TableCell = new HtmlTableCell();
                    HtmlTableCell cityTableCell = new HtmlTableCell();
                    HtmlTableCell stateTableCell = new HtmlTableCell();
                    HtmlTableCell zipTableCell = new HtmlTableCell();
                    HtmlTableCell addressActionTableCell = new HtmlTableCell();

                    addressIDTableCell.InnerText = personAddress.AddressID.ToString(); //some time wrap in some control, JQuery
                    street1TableCell.InnerText = personAddress.Street1.ToString();
                    street2TableCell.InnerText = personAddress.Street2.ToString();
                    cityTableCell.InnerText = personAddress.City.ToString();
                    stateTableCell.InnerText = personAddress.State.ToString();
                    zipTableCell.InnerText = personAddress.Zip.ToString();

                    PlaceHolder ph = new PlaceHolder();
                    LinkButton lbe = new LinkButton();
                    LiteralControl litEdit = new LiteralControl();

                    int x = person.ID;
                   // int yy = emailAddress.EmailAddressID;
                    int y = personAddress.AddressID;
                   // addressActionTableCell.InnerHtml = "<INPUT Type='BUTTON' VALUE='Edit' ONCLICK='window.location.href='http://www.treasurepointaudio.com''><INPUT Type='BUTTON' VALUE='Delete' ONCLICK='window.location.href='http://www.treasurepointaudio.com''>";
                    HtmlInputButton btn = new HtmlInputButton();
                 btn.Attributes.Add("value", "Delete");
                   
                    btn.Attributes.Add("onclick", "window.location='AddressForm.aspx?Mode=Delete&PersonID=" +  x  + "&AddressID=" + y + "'");

                   // btn_delete.Attributes.Add("onclick", "if(confirm('Are you sure that you want to delete this comment?')){return true;} else {return false;};");





                    HtmlInputButton btn2 = new HtmlInputButton();
                    btn2.Attributes.Add("value", "Update");
                                  
                    //btn2.Attributes.Add("onclick", "window.location.href='http://www.treasurepointaudio.com");
                    btn2.Attributes.Add("onclick", "window.location='AddressForm.aspx?Mode=Edit&PersonID=" + x + "&AddressID=" + y + "'");

                    addressActionTableCell.Controls.Add(btn);
                    addressActionTableCell.Controls.Add(btn2);
                    addressTableRow.Cells.Add(addressIDTableCell);
                    addressTableRow.Cells.Add(street1TableCell);
                    addressTableRow.Cells.Add(street2TableCell);
                    addressTableRow.Cells.Add(cityTableCell);
                    addressTableRow.Cells.Add(stateTableCell);
                    addressTableRow.Cells.Add(zipTableCell);
                    addressTableRow.Cells.Add(addressActionTableCell);

                    addressTable.Rows.Add(addressTableRow);

                }
               // this.Controls.Add(addressTable);
                phAddressTable.Controls.Add(addressTable);
                
            }

            if (person.Addresses.Count == 0)
            {
                System.Web.UI.HtmlControls.HtmlTable addressTable = new System.Web.UI.HtmlControls.HtmlTable();
                addressTable.Border = 1;
                addressTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell messageTableCell = new HtmlTableCell();

                //message results for Addresses Tables if there are no results
                messageTableCell.InnerText = "Sorry there are no results.";
                headerTableRow.Cells.Add(messageTableCell);
                addressTable.Rows.Add(headerTableRow);

                phAddressTable.Controls.Add(addressTable);
     
            }

        }
        #endregion

        #region "Fill Phones"
        private void fillPersonPhones()
        {
            BusinessObjects.Person person = new BusinessObjects.Person(1);
            
            if (person.Phones.Count > 0)
            {
                System.Web.UI.HtmlControls.HtmlTable phoneTable = new System.Web.UI.HtmlControls.HtmlTable();
                phoneTable.Border = 1;
                phoneTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell phoneIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell areaCodeHeaderTableCell = new HtmlTableCell();
                HtmlTableCell phoneNumberHeaderTableCell = new HtmlTableCell();
                HtmlTableCell extensionHeaderTableCell = new HtmlTableCell();
                HtmlTableCell phoneTypeIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell phoneActionHeaderTableCell = new HtmlTableCell();

                phoneIDHeaderTableCell.InnerText = "Phone ID";
                areaCodeHeaderTableCell.InnerText = "Area Code";
                phoneNumberHeaderTableCell.InnerText = "Phone Number";
                extensionHeaderTableCell.InnerText = "Extension";
                phoneTypeIDHeaderTableCell.InnerText = "Phone Type ID";
                phoneActionHeaderTableCell.InnerText = "Action";

                headerTableRow.Cells.Add(phoneIDHeaderTableCell);
                headerTableRow.Cells.Add(areaCodeHeaderTableCell);
                headerTableRow.Cells.Add(phoneNumberHeaderTableCell);
                headerTableRow.Cells.Add(extensionHeaderTableCell);
                headerTableRow.Cells.Add(phoneTypeIDHeaderTableCell);
                headerTableRow.Cells.Add(phoneActionHeaderTableCell);

                phoneTable.Rows.Add(headerTableRow);

                foreach (BusinessObjects.PersonPhone personPhone in person.Phones)
                {
                    HtmlTableRow phoneTableRow = new HtmlTableRow();
                    HtmlTableCell phoneIDTableCell = new HtmlTableCell();
                    HtmlTableCell areaCodeTableCell = new HtmlTableCell();
                    HtmlTableCell phoneNumberTableCell = new HtmlTableCell();
                    HtmlTableCell extensionTableCell = new HtmlTableCell();
                    HtmlTableCell phoneTypeIDTableCell = new HtmlTableCell();
                    HtmlTableCell phoneActionTableCell = new HtmlTableCell();

                    phoneIDTableCell.InnerText = personPhone.PhoneID.ToString(); //some time wrap in some control, JQuery
                    areaCodeTableCell.InnerText = personPhone.AreaCode.ToString();
                    phoneNumberTableCell.InnerText = personPhone.PhoneNumber.ToString();
                    extensionTableCell.InnerText = personPhone.Extension.ToString();
                   // phoneTypeIDTableCell.InnerText = personPhone.PhoneTypeID.ToString();

                    int pPhone = Convert.ToInt32(personPhone.PhoneTypeID.ToString());
                    switch (pPhone)
                    {
                        case 1:
                            phoneTypeIDTableCell.InnerText = "Home";
                            break;

                        case 2:
                            phoneTypeIDTableCell.InnerText = "Work";
                            break;

                        case 3:
                            phoneTypeIDTableCell.InnerText = "Cell";
                            break;
                    }
                  //  phoneTypeIDTableCell.InnerText = personPhone.PhoneTypeID.
                  //  phoneActionTableCell.InnerHtml = "<FORM><INPUT Type='BUTTON' VALUE='E' ONCLICK='window.location.href='http://www.treasurepointaudio.com''><INPUT Type='BUTTON' VALUE='Delete' ONCLICK='window.location.href='http://www.treasurepointaudio.com''></FORM>";
                   
                    LinkButton lnkEdit = new LinkButton();
                    LinkButton lnkUpdate = new LinkButton();
                    LiteralControl litEdit = new LiteralControl();
                    HtmlInputButton btnDelete = new HtmlInputButton();

                    int x = person.ID;
                    int y = personPhone.PhoneID;
                    btnDelete.Attributes.Add("value", "Delete");
                    //btn_delete.Attributes.Add("onclick", "if(confirm('Are you sure that you want to delete this comment?')){return true;} else {return false;};");
                   
                    btnDelete.Attributes.Add("onclick", "window.location='TelephoneForm.aspx?Mode=Delete&PersonID=" + x + "&PhoneID=" + y + "'");

                    HtmlInputButton btn3 = new HtmlInputButton();
                    btn3.Attributes.Add("value", "Update");
                  
                    btn3.Attributes.Add("onclick", "window.location='TelephoneForm.aspx?Mode=Edit&PersonID=" + x + "&PhoneID=" + y + "'");
                    phoneActionTableCell.Controls.Add(btnDelete);
                    phoneActionTableCell.Controls.Add(btn3);
                                     
                    phoneTableRow.Cells.Add(phoneIDTableCell);
                    phoneTableRow.Cells.Add(areaCodeTableCell);
                    phoneTableRow.Cells.Add(phoneNumberTableCell);
                    phoneTableRow.Cells.Add(extensionTableCell);
                    phoneTableRow.Cells.Add(phoneTypeIDTableCell);
                    phoneTableRow.Cells.Add(phoneActionTableCell);
                    phoneTable.Rows.Add(phoneTableRow);

                }

               phTelephoneTable.Controls.Add(phoneTable);

            }

               if (person.Phones.Count == 0)
            {
                System.Web.UI.HtmlControls.HtmlTable phoneTable = new System.Web.UI.HtmlControls.HtmlTable();
                phoneTable.Border = 1;
                phoneTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell messageTableCell = new HtmlTableCell();

                messageTableCell.InnerText = "Sorry there are no results.";

                headerTableRow.Cells.Add(messageTableCell);

                phoneTable.Rows.Add(headerTableRow);

                phTelephoneTable.Controls.Add(phoneTable);
                //add table and add message that says no entries. 
            }
        }
        #endregion

        #region "Fill Email Addresses"
        private void fillEmailAddresses()
        {
              BusinessObjects.Person person = new BusinessObjects.Person(1);

            if (person.EmailAddresses.Count > 0)
            {
                System.Web.UI.HtmlControls.HtmlTable emailAddressTable = new System.Web.UI.HtmlControls.HtmlTable();
                emailAddressTable.Border = 1;
                emailAddressTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell emailAddressIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell addressHeaderTableCell = new HtmlTableCell();
                HtmlTableCell personIDHeaderTableCell = new HtmlTableCell();
                HtmlTableCell emailActionHeaderTableCell = new HtmlTableCell();

                emailAddressIDHeaderTableCell.InnerText = "Email Address ID";
                addressHeaderTableCell.InnerText = "Address";
                personIDHeaderTableCell.InnerText = "Person ID";
                emailActionHeaderTableCell.InnerText = "Action";

                headerTableRow.Cells.Add(emailAddressIDHeaderTableCell);
                headerTableRow.Cells.Add(addressHeaderTableCell);
                headerTableRow.Cells.Add(personIDHeaderTableCell);
                headerTableRow.Cells.Add(emailActionHeaderTableCell);

                emailAddressTable.Rows.Add(headerTableRow);

                foreach (BusinessObjects.EmailAddress emailAddress in person.EmailAddresses)
                {
                    HtmlTableRow emailAddressTableRow = new HtmlTableRow();
                    HtmlTableCell emailAddressIDTableCell = new HtmlTableCell();
                    HtmlTableCell addressTableCell = new HtmlTableCell();
                    HtmlTableCell personIDTableCell = new HtmlTableCell();
                    HtmlTableCell emailActionTableCell = new HtmlTableCell();

                    emailAddressIDTableCell.InnerText = emailAddress.EmailAddressID.ToString(); //some time wrap in some control, JQuery
                    addressTableCell.InnerText = emailAddress.Address.ToString();
                    personIDTableCell.InnerText = emailAddress.PersonID.ToString();
                  //////  emailTableCell.InnerHtml = "<FORM><INPUT Type='BUTTON' VALUE='Delete' ONCLICK='window.location.href='http://www.treasurepointaudio.com''><INPUT Type='BUTTON' VALUE='Update' ONCLICK='window.location.href='http://www.treasurepointaudio.com''></FORM>";
                    int x = person.ID;
                    int y = emailAddress.EmailAddressID;

                    HtmlInputButton btnDelete = new HtmlInputButton();
                    btnDelete.Attributes.Add("value", "Delete");
                    btnDelete.Attributes.Add("onclick", "window.location='EmailForm.aspx?Mode=Delete&PersonID=" +  x  + "&EmailAddressID=" + y + "'");

                    HtmlInputButton btn4 = new HtmlInputButton();
                    btn4.Attributes.Add("value", "Update");

                    btn4.Attributes.Add("onclick", "window.location='EmailForm.aspx?Mode=Edit&PersonID=" + x + "&EmailAddressID=" + y +"'");
                    emailActionTableCell.Controls.Add(btnDelete);
                    emailActionTableCell.Controls.Add(btn4);
                    
                    emailAddressTableRow.Cells.Add(emailAddressIDTableCell);
                    emailAddressTableRow.Cells.Add(addressTableCell);
                    emailAddressTableRow.Cells.Add(personIDTableCell);
                    emailAddressTableRow.Cells.Add(emailActionTableCell);

                    emailAddressTable.Rows.Add(emailAddressTableRow);

                }
                //this.Controls.Add(emailAddressTable);
                phEmailAddressTable.Controls.Add(emailAddressTable);
            }

            if (person.EmailAddresses.Count == 0)
            {
                System.Web.UI.HtmlControls.HtmlTable emailAddressTable = new System.Web.UI.HtmlControls.HtmlTable();
                emailAddressTable.Border = 1;
                emailAddressTable.CellPadding = 3;
                HtmlTableRow headerTableRow = new HtmlTableRow();
                HtmlTableCell messageTableCell = new HtmlTableCell();
               
                messageTableCell.InnerText = "Sorry there are no results.";
                
                headerTableRow.Cells.Add(messageTableCell);
               
                emailAddressTable.Rows.Add(headerTableRow);
                phEmailAddressTable.Controls.Add(emailAddressTable);
            }
        }
        #endregion

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            //Sent the value of the txt
            int x = Convert.ToInt32(txtID.Text);
            Response.Redirect("AddressForm.aspx?Mode=New&PersonID=" + x);
        }

        protected void btnPhone_Click(object sender, EventArgs e)
        {
            //Sent the value of the txt
            int x = Convert.ToInt32(txtID.Text);
            Response.Redirect("TelephoneForm.aspx?Mode=New&PersonID=" + x);
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            Response.Redirect("EmailForm.aspx?Mode=New&PersonID=" + x);
        }

        //btnDelete OnClick Handler

    }
}