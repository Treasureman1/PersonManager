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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessObjects.Person person = new BusinessObjects.Person(1);

            if (person.Addresses.Count > 0)
            {
                System.Web.UI.HtmlControls.HtmlTable addressTable = new System.Web.UI.HtmlControls.HtmlTable();
                System.Web.UI.HtmlControls.HtmlTableRow addressIDRow = new System.Web.UI.HtmlControls.HtmlTableRow();
                System.Web.UI.HtmlControls.HtmlTableRow addressDataRow = new System.Web.UI.HtmlControls.HtmlTableRow();

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

                addressTable.Border = 1;


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

                
                addressIDLabelCell.Controls.Add(lblAddID);
                addressIDLiteralCell.Controls.Add(litAddID);
                str1LabelCell.Controls.Add(lblStr1);
                str1LiteralCell.Controls.Add(litStr1);
                str2LabelCell.Controls.Add(lblStr2);
                str2LiteralCell.Controls.Add(litStr2);
                citLabelCell.Controls.Add(lblCit);
                citLiteralCell.Controls.Add(litCit);
                stLabelCell.Controls.Add(lblSt);
                stLiteralCell.Controls.Add(litSt);
                zLabelCell.Controls.Add(lblZ);
                zLiteralCell.Controls.Add(litZ);

                addressTable.Rows.Add(addressIDRow);
                addressIDRow.Cells.Add(addressIDLabelCell);
                addressIDRow.Cells.Add(str1LabelCell);
                addressIDRow.Cells.Add(str2LabelCell);
                addressIDRow.Cells.Add(citLabelCell);
                addressIDRow.Cells.Add(stLabelCell);
                addressIDRow.Cells.Add(zLabelCell);
                
                //foreach (BusinessObjects.PersonAddress personAddresses in person.Addresses)
                //{
                   
                //    addressIDRow = new HtmlTableRow();

                //   addressIDLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                // str1LiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                //     str2LiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                //     citLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                //    stLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                //    zLiteralCell = new System.Web.UI.HtmlControls.HtmlTableCell();

                //    litAddID.Text = person.Addresses[i].AddressID.ToString();
                //    litStr1.Text = person.Addresses[i].Street1.ToString();
                //    litStr2.Text = person.Addresses[i].Street2.ToString();
                //    litCit.Text = person.Addresses[i].City.ToString();
                //    litSt.Text = person.Addresses[i].State.ToString();
                //    litZ.Text = person.Addresses[i].Zip.ToString();

                //    addressIDLiteralCell.Controls.Add(litAddID);
                //    str1LiteralCell.Controls.Add(litStr1);
                //    str2LiteralCell.Controls.Add(litStr2);
                //    citLiteralCell.Controls.Add(litCit);
                //    stLiteralCell.Controls.Add(litSt);
                //    zLiteralCell.Controls.Add(litZ);

                //    addressTable.Rows.Add(addressIDRow);
                //    addressIDRow.Cells.Add(addressIDLiteralCell);
                //    addressIDRow.Cells.Add(str1LiteralCell);
                //    addressIDRow.Cells.Add(str2LiteralCell);
                //    addressIDRow.Cells.Add(citLiteralCell);
                //    addressIDRow.Cells.Add(stLiteralCell);
                //    addressIDRow.Cells.Add(zLiteralCell);

                //    i += 1;

                //}

                Page.Form.Controls.Add(addressTable);
               
            }
        }
    }
}