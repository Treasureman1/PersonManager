using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Web.UI.Page;



namespace System
{
    
    public partial class Randomize_CHAR : System.Web.UI.Page 
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            int month = rnd.Next(1, 13); // creates a number between 1 and 12
            int dice = rnd.Next(1, 7); // creates a number between 1 and 6
            int card = rnd.Next(52); // creates a number between 0 and 51

            
            Random random = new Random();
            int randomNumber = random.Next(0, 100);


            string[] secondRandomCHAR = new string[8];

        }

        protected void btnRandomCHAR_Click(object sender, EventArgs e)
        {
            //if String has only x amount of characters, then only add 6 random characters, and if there are 500 then add %10
            // of 500 words to the file,
            // txtInput.Text = "Audiopipe AP1500.1D 1 Channel amplifier. Audiopipe AP1500.1D Monoblock Class D amplifier1000 x 1 @ 2 Ohms. Get This Great Class D technology with a great exterior frame. 4 gauge input, with Class D 1 Ohm Stable Tecnology. Get this great amplifer for only 199.99 right now at Treasure Point Audio.or give us a call toll free 1-866-643-5822!Open Mon. - Sat. 10 to 6 Eastern ";
            string[] randomCHAR = { "!", "+", "@", "$", "*", "#", "-", "=" };  //Insert collection of Arrays, so there can be many to choose from 
            foreach (string oneRandomCHAR in randomCHAR)
            {
                int i = 0;
                
               
                i++;
            }

            oneRandomCharacter();
        }


        string[] nameString = { "Tom", "Tim", "John", "George" };

     


        private int oneRandomCharacter()
        {
            
            Random random = new Random();
            int randomNumber = random.Next(0, 8);
            lstOutput.Items.Add(randomNumber.ToString());
            
            
            return randomNumber;
        }





        //  for (int i = 0; i < theData.Length; i++)

        //grab 3 items at a time and do db insert, continue until all items are gone. 'theData' will always be divisible by 3.



        //class TestArraysClass
        //{
        //    static void Main()
        //    {
        //        // Declare a single-dimensional array  
        //        int[] array1 = new int[5];

        //        // Declare and set array element values 
        //        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        //        // Alternative syntax 
        //        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        //        // Declare a two dimensional array 
        //        int[,] multiDimensionalArray1 = new int[2, 3];

        //        // Declare and set array element values 
        //        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        //        // Declare a jagged array 
        //        int[][] jaggedArray = new int[6][];

        //        // Set the values of the first array in the jagged array structure
        //        jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
        //    }
        //}
        


    }

  
}