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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int i = 0;
            //int j = 0;
            //int k = 0;
       




          
            
           // cellStr.Text = "HtmlTableCell cell" + j.ToString() + " new HtmlTableCell();";
           // cellDataStr.Text = "cell" + k.ToString() + ".InnerText = 'This is dynamic cell" + " " + i.ToString();
           //AddRowStr.Text = "row" + i.ToString() + ".Cells.Add(cell" + i.ToString() + ");";
           //AddTableStr.Text = "table2.Rows.Add(row" + i.ToString() + ");";
          
            
            // System.Web.UI.WebControls.Literal
            //foreach (var item in Name)
            //{
            //    row = new HtmlTableRow();

            //    foreach (var familyName in item.familyName)
            //    {
            //        cell = new HtmlTableCell();
            //        cell.InnerText = item.familyName.ToString();
            //        row.Cells.Add(cell);
            //    }
            //    foreach (var givenName in item.givenName)
            //    {
            //        cell = new HtmlTableCell();
            //        cell.InnerText = item.givenName.ToString();
            //        row.Cells.Add(cell);
            //    }

            //    table.Rows.Add(row);
            //}
            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //I need to dynamically create the instance with code, for instance table[i] needs to be systematically created
            //int i = 0;
            System.Web.UI.HtmlControls.HtmlTable Htable = new HtmlTable();
            System.Web.UI.HtmlControls.HtmlTableRow Hrow = new HtmlTableRow();
            System.Web.UI.HtmlControls.HtmlTableCell cell01 = new HtmlTableCell();  //I want to try to concatenate
            //use a literal to build the statement, then assign a differents literal the text  alue of the statement string. 
            System.Web.UI.HtmlControls.HtmlTableCell cell02 = new HtmlTableCell();
            System.Web.UI.HtmlControls.HtmlTableCell cell03 = new HtmlTableCell();

             Label Label1 = new Label();
            Label1.Text = "1";
            Label Label2 = new Label();
            Label2.Text = "Tom Jenkins";
            Label Label3 = new Label();
            Label3.Text = "t@t.com";

            Literal lit1 = new Literal();
            Literal lit2 = new Literal();
            Literal lit3 = new Literal();

            lit1.Text = "Literal 1";
            lit2.Text = "Literal 2";
            lit3.Text = "Literal 3";

            Htable.Border = 1;
            cell01.InnerHtml = "ID";
            cell02.InnerHtml = "Name";
            cell03.InnerHtml = "email";

            Hrow.Cells.Add(cell01);
            Hrow.Cells.Add(cell02);
            Hrow.Cells.Add(cell03);
            Htable.Rows.Add(Hrow);

            cell01 = new HtmlTableCell();
            cell02 = new HtmlTableCell();
            cell03 = new HtmlTableCell();

            cell01.InnerHtml = lit1.ToString();
            cell02.InnerHtml = lit2.ToString();
            cell03.InnerHtml = lit3.ToString();
            Hrow = new HtmlTableRow();
            Hrow.Cells.Add(cell01);
            Hrow.Cells.Add(cell02);
            Hrow.Cells.Add(cell03);

            Htable.Rows.Add(Hrow);
            this.Controls.Add(Htable);
           

          //do while (i < 3)
          //  {
             
          //    i++;
          //  }

            //string[] arr = new string[4]; // Initialize
            //arr[0] = "one";               // Element 1
            //arr[1] = "two";               // Element 2
            //arr[2] = "three";             // Element 3
            //arr[3] = "four";              // Element 4

            //// Loop over strings
            //foreach (string s in arr)
            //{
            //    Console.WriteLine(s);
            //}


           //// Array a1 = new Array[1, 2, 3, 4];
           // string[] a1 = new string[2];
           // a1[0] = "First Element";
           // a1[1] = "Second Element";
           // a1[2] = "Third Element";
           // foreach (string s in a1)
           // {
           //     Label lba = new Label();
           //     lba.Text = a1[i].ToString();
                
              
           //     Console.WriteLine(s);
           // }


            



            // for i = o while i is less than row count plus or minus 1, loop through and array and do something to practice looping data with arrays, collections, and tables. 
            //A tables, b for each loops with different types of data, and C using an array to work on this and add data. Use these controls in an array. 
            //DynamicControlsPlaceholder (DCP) 




                //look into web controls, what they cand be used for, and how they differ from HTML table contr
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HtmlTable table = new HtmlTable();
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableRow rowB = new HtmlTableRow();
            HtmlTableRow rowC = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();
            HtmlTableCell cell4 = new HtmlTableCell();
            HtmlTableCell cell5 = new HtmlTableCell();
            HtmlTableCell cell6 = new HtmlTableCell();
            HtmlTableCell cell7 = new HtmlTableCell();
            HtmlTableCell cell8 = new HtmlTableCell();
            HtmlTableCell cell9 = new HtmlTableCell();
            cell.InnerText = "This is Column 1";
            cell2.InnerText = "This is Column 2";
            cell3.InnerText = " This is Column 3";
            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            table.Rows.Add(row);
            cell4.InnerText = "column 4";
            cell5.InnerText = "column 5";
            cell6.InnerText = "Column 6";
            rowB.Cells.Add(cell4);
            rowB.Cells.Add(cell5);
            rowB.Cells.Add(cell6);
            table.Rows.Add(rowB);

            cell = new HtmlTableCell();
            cell.InnerText = "this is the new cell";
           
            cell1.InnerText = "this is the new cell1";
            cell2 = new HtmlTableCell();
            cell2.InnerText = "this is the new cell3";
            rowC.Cells.Add(cell);
            rowC.Cells.Add(cell1);
            rowC.Cells.Add(cell2);
            table.Rows.Add(rowC);

            //cell7.InnerText = "again with 4";
            //cell8.InnerText = "again with 5";
            //cell9.InnerText = "again with 6";
            //rowC.Cells.Add(cell7);
            //rowC.Cells.Add(cell8);
            //rowC.Cells.Add(cell9);
            //table.Rows.Add(rowC);



            this.Controls.Add(table);

            //use a literal control to change the names of the rows and cells with the iterator i give this some thougt. 
            //table2 will consist of cell1, cell2, cell3, row1, row2, row3

        }

        protected void btnLiteralTable_Click(object sender, EventArgs e)
        {

            System.Web.UI.HtmlControls.HtmlTable tableT = new System.Web.UI.HtmlControls.HtmlTable();
            System.Web.UI.HtmlControls.HtmlTableRow rowR = new System.Web.UI.HtmlControls.HtmlTableRow();
            System.Web.UI.HtmlControls.HtmlTableCell cellA = new System.Web.UI.HtmlControls.HtmlTableCell();
            System.Web.UI.HtmlControls.HtmlTableCell cellB = new System.Web.UI.HtmlControls.HtmlTableCell();

            System.Web.UI.HtmlControls.HtmlTableCell cellC = new System.Web.UI.HtmlControls.HtmlTableCell();
            cellA.InnerText = "t2 C1Header";
            cellB.InnerText = "t2 C2Header";
            cellC.InnerText = "t2 C3Header";
            rowR.Cells.Add(cellA);
            rowR.Cells.Add(cellB);
            rowR.Cells.Add(cellC);
            tableT.Rows.Add(rowR);
            cellA = new HtmlTableCell();
            cellB = new HtmlTableCell();
            cellC = new HtmlTableCell();
            rowR = new HtmlTableRow();
            cellA.InnerText = "r1c1";
            cellB.InnerHtml = "r2c2";
            cellC.InnerText = "r3c3";
            rowR.Cells.Add(cellA);
            rowR.Cells.Add(cellB);
            rowR.Cells.Add(cellC);
            tableT.Rows.Add(rowR);

            this.Controls.Add(tableT);

        }

        protected void btnRowTable_Click(object sender, EventArgs e)
        {

            HtmlTable table = new HtmlTable();
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableRow rowB = new HtmlTableRow();
            HtmlTableRow rowC = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();
            HtmlTableCell cell4 = new HtmlTableCell();
            HtmlTableCell cell5 = new HtmlTableCell();
            HtmlTableCell cell6 = new HtmlTableCell();
            HtmlTableCell cell7 = new HtmlTableCell();
            HtmlTableCell cell8 = new HtmlTableCell();
            HtmlTableCell cell9 = new HtmlTableCell();
            cell.InnerText = "This is Column 1";
            cell2.InnerText = "This is Column 2";
            cell3.InnerText = " This is Column 3";
            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            table.Rows.Add(row);
            row = new HtmlTableRow();
            cell = new HtmlTableCell();
            cell2 = new HtmlTableCell();
            cell3 = new HtmlTableCell();
            cell.InnerText = "column 4a";
            cell2.InnerText = "column 5a";
            cell3.InnerText = "Column 6a";
            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            table.Rows.Add(row);

            cell = new HtmlTableCell();
            cell.InnerText = "this is the new cell";
            cell1 = new HtmlTableCell();
            cell1.InnerText = "this is the new cell1";
            cell2 = new HtmlTableCell();
            cell2.InnerText = "this is the new cell3";
            row = new HtmlTableRow();
            row.Cells.Add(cell);
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            table.Rows.Add(row);

            //cell7.InnerText = "again with 4";
            //cell8.InnerText = "again with 5";
            //cell9.InnerText = "again with 6";
            //rowC.Cells.Add(cell7);
            //rowC.Cells.Add(cell8);
            //rowC.Cells.Add(cell9);
            //table.Rows.Add(rowC);



            this.Controls.Add(table);

        }


    }
}