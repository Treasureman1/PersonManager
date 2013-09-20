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
    public partial class WebForm2 : System.Web.UI.Page
    {
        LiteralControl litPersonID = new LiteralControl();
        LiteralControl litTitle = new LiteralControl();
        LiteralControl litFirstName = new LiteralControl();
        LiteralControl litLastName = new LiteralControl(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessObjects.Person person = new BusinessObjects.Person(1);

            litPersonID.Text = person.ID.ToString();
            litTitle.Text = person.Title;
            litFirstName.Text = person.FirstName;
            litLastName.Text = person.LastName;

            if (person.Addresses.Count > 0)
            {

                System.Web.UI.HtmlControls.HtmlTable addressTable = new System.Web.UI.HtmlControls.HtmlTable();
                System.Web.UI.HtmlControls.HtmlTableRow addressIDRow = new System.Web.UI.HtmlControls.HtmlTableRow();
                System.Web.UI.HtmlControls.HtmlTableRow addressDataRow = new System.Web.UI.HtmlControls.HtmlTableRow();
                System.Web.UI.HtmlControls.HtmlTableRow addressDataRow2 = new System.Web.UI.HtmlControls.HtmlTableRow();


                System.Web.UI.HtmlControls.HtmlTableCell addressIDLabelCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell str1LabelCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell str2LabelCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell citLabelCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell stLabelCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell zLabelCell = new System.Web.UI.HtmlControls.HtmlTableCell();

                System.Web.UI.HtmlControls.HtmlTableCell addressIDLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell str1LiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell str2LiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell citLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell stLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlTableCell zLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();


                Label lblAddID = new Label();
                Literal litAddID = new Literal();
                Label lblStr1 = new Label();
                Literal litStr1 = new Literal();
                Label lblStr2 = new Label();
                Literal litStr2 = new Literal();
                Label lblCit = new Label();
                Literal litCit = new Literal();
                Label lblSt = new Label();
                Literal litSt = new Literal();
                Label lblZ = new Label();
                Literal litZ = new Literal();

                lblAddID.Text = "Address ID: ";
                lblStr1.Text = "Street 1: ";
                lblStr2.Text = "Street 2: ";
                lblCit.Text = "City: ";
                lblSt.Text = "State: ";
                lblZ.Text = "Zip: ";
                int i = 0;
                litAddID.Text = person.Addresses[i].AddressID.ToString();
                litStr1.Text = person.Addresses[i].Street1.ToString();
                litStr2.Text = person.Addresses[i].Street2.ToString();
                litCit.Text = person.Addresses[i].City.ToString();
                litSt.Text = person.Addresses[i].State.ToString();
                litZ.Text = person.Addresses[i].Zip.ToString();


                addressIDLabelCell.Controls.Add(lblAddID);  //the addressIDLabelCell
               addressIDLiteralCell.Controls.Add(litAddID);
                str1LabelCell.Controls.Add(lblStr1);
               // str1LiteralCell.Controls.Add(litStr1);
                str2LabelCell.Controls.Add(lblStr2);
             //   str2LiteralCell.Controls.Add(litStr2);
                citLabelCell.Controls.Add(lblCit);
               // citLiteralCell.Controls.Add(litCit);
                stLabelCell.Controls.Add(lblSt);
              //  stLiteralCell.Controls.Add(litSt);
                zLabelCell.Controls.Add(lblZ);
              //  zLiteralCell.Controls.Add(litZ);

                //This is what displays the labels on the first row. AddressID, Street, Street, City, State, Zip 
                addressTable.Rows.Add(addressIDRow);
                addressIDRow.Cells.Add(addressIDLabelCell);
                addressIDRow.Cells.Add(str1LabelCell);
                addressIDRow.Cells.Add(str2LabelCell);
                addressIDRow.Cells.Add(citLabelCell);
                addressIDRow.Cells.Add(stLabelCell);
                addressIDRow.Cells.Add(zLabelCell);


                foreach (BusinessObjects.PersonAddress personAddresses in person.Addresses)
                {
                    //69 to 99 on webform 3
                    addressDataRow = new HtmlTableRow();
                addressIDLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    str1LiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    str2LiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    citLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    stLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    zLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();

                    litAddID.Text = person.Addresses[i].AddressID.ToString();
                    litStr1.Text = person.Addresses[i].Street1.ToString();
                    litStr2.Text = person.Addresses[i].Street2.ToString();
                    litCit.Text = person.Addresses[i].City.ToString();
                    litSt.Text = person.Addresses[i].State.ToString();
                    litZ.Text = person.Addresses[i].Zip.ToString();

                    addressIDLiteralCell.Controls.Add(litAddID);
                    //str1LabelCell.Controls.Add(lblStr1);
                    str1LiteralCell.Controls.Add(litStr1);
                    //str2LabelCell.Controls.Add(lblStr2);
                    str2LiteralCell.Controls.Add(litStr2);
                    //citLabelCell.Controls.Add(lblCit);
                    citLiteralCell.Controls.Add(litCit);
                    // stLabelCell.Controls.Add(lblSt);
                    stLiteralCell.Controls.Add(litSt);
                    // zLabelCell.Controls.Add(lblZ);
                    zLiteralCell.Controls.Add(litZ);

                    addressDataRow.Cells.Add(addressIDLiteralCell);
                    addressDataRow.Cells.Add(str1LiteralCell);

                    addressDataRow.Cells.Add(str2LiteralCell);
                    addressDataRow.Cells.Add(citLiteralCell);
                    addressDataRow.Cells.Add(stLiteralCell);
                    addressDataRow.Cells.Add(zLiteralCell);

                    addressTable.Rows.Add(addressDataRow);

                  
                Page.Form.Controls.Add(addressTable);
                this.Controls.Add(addressTable);
            }

        }
    }
}



    //
    // //////////////////////////////////////////////////below first loop example
    // addressTable.Rows.Add(addressDataRow);  //This Row Successfully adds the first group of names to

    // //addressIDLabelCell.Controls.Add(lblAddID); // I think that I need to add this again to the end of the block
    // addressIDLiteralCell.Controls.Add(litAddID);
    // //str1LabelCell.Controls.Add(lblStr1);
    // str1LiteralCell.Controls.Add(litStr1);
    // //str2LabelCell.Controls.Add(lblStr2);
    // str2LiteralCell.Controls.Add(litStr2);
    // //citLabelCell.Controls.Add(lblCit);
    // citLiteralCell.Controls.Add(litCit);
    // // stLabelCell.Controls.Add(lblSt);
    // stLiteralCell.Controls.Add(litSt);
    // // zLabelCell.Controls.Add(lblZ);
    // zLiteralCell.Controls.Add(litZ);




    // addressDataRow.Cells.Add(addressIDLiteralCell);
    // addressDataRow.Cells.Add(str1LiteralCell);

    // addressDataRow.Cells.Add(str2LiteralCell);
    // addressDataRow.Cells.Add(citLiteralCell);
    // addressDataRow.Cells.Add(stLiteralCell);
    // addressDataRow.Cells.Add(zLiteralCell);

    // addressTable.Rows.Add(addressDataRow);

    //// addressIDRow.Cells.Add(addressIDLabelCell);



    //  i += 1;

    // litAddID.Text = person.Addresses[i].AddressID.ToString();
    // litStr1.Text = person.Addresses[i].Street1.ToString();
    // litStr2.Text = person.Addresses[i].Street2.ToString();
    // litCit.Text = person.Addresses[i].City.ToString();
    // litSt.Text = person.Addresses[i].State.ToString();
    // litZ.Text = person.Addresses[i].Zip.ToString();



}
//    addressDataRow = new HtmlTableRow();
//    litAddID.Text = person.Addresses[i].AddressID.ToString();
//    litStr1.Text = person.Addresses[i].Street1.ToString();
//    litStr2.Text = person.Addresses[i].Street2.ToString();
//    litCit.Text = person.Addresses[i].City.ToString();
//    litSt.Text = person.Addresses[i].State.ToString();
//    litZ.Text = person.Addresses[i].Zip.ToString();


//    addressIDLiteralCell.Controls.Add(litAddID);
//    str1LabelCell.Controls.Add(lblStr1);
//    // str1LiteralCell.Controls.Add(litStr1);
//    str2LabelCell.Controls.Add(lblStr2);
//    //   str2LiteralCell.Controls.Add(litStr2);
//    citLabelCell.Controls.Add(lblCit);
//    // citLiteralCell.Controls.Add(litCit);
//    stLabelCell.Controls.Add(lblSt);
//    //  stLiteralCell.Controls.Add(litSt);
//    zLabelCell.Controls.Add(lblZ);
//    //  zLiteralCell.Controls.Add(litZ);

//litAddID.Text = person.Addresses[i].AddressID.ToString();
//litStr1.Text = person.Addresses[i].Street1.ToString();
//litStr2.Text = person.Addresses[i].Street2.ToString();
//litCit.Text = person.Addresses[i].City.ToString();
//litSt.Text = person.Addresses[i].State.ToString();
//litZ.Text = person.Addresses[i].Zip.ToString();

//addressTable.Rows.Add(addressDataRow2);


///////////////////////////////////////////////////////////////////
//addressIDLiteralCell.Controls.Add(litAddID);
////str1LabelCell.Controls.Add(lblStr1);
//str1LiteralCell.Controls.Add(litStr1);
////str2LabelCell.Controls.Add(lblStr2);
//str2LiteralCell.Controls.Add(litStr2);
////citLabelCell.Controls.Add(lblCit);
//citLiteralCell.Controls.Add(litCit);
//// stLabelCell.Controls.Add(lblSt);
//stLiteralCell.Controls.Add(litSt);
//// zLabelCell.Controls.Add(lblZ);
//zLiteralCell.Controls.Add(litZ);

//addressDataRow2.Cells.Add(addressIDLiteralCell);
//addressDataRow2.Cells.Add(str1LiteralCell);

//addressDataRow2.Cells.Add(str2LiteralCell);
//addressDataRow2.Cells.Add(citLiteralCell);
//addressDataRow2.Cells.Add(stLiteralCell);
//addressDataRow2.Cells.Add(zLiteralCell);


//i += 1;
//addressDataRow2 = new HtmlTableRow();
//litAddID.Text = person.Addresses[i].AddressID.ToString();
//litStr1.Text = person.Addresses[i].Street1.ToString();
//litStr2.Text = person.Addresses[i].Street2.ToString();
//litCit.Text = person.Addresses[i].City.ToString();
//litSt.Text = person.Addresses[i].State.ToString();
//litZ.Text = person.Addresses[i].Zip.ToString();

//addressTable.Rows.Add(addressDataRow2);
////////////////////////////////////////////////////////////////////////

//}
//addressDataRow2.Cells.Add(addressIDLiteralCell);
//addressDataRow2.Cells.Add(str1LiteralCell);

//addressDataRow2.Cells.Add(str2LiteralCell);
//addressDataRow2.Cells.Add(citLiteralCell);
//addressDataRow2.Cells.Add(stLiteralCell);
//addressDataRow2.Cells.Add(zLiteralCell);