/* Student Name: Rajan Nayak
 * Student ID: 19230344
 * Date: 01/12/2019
 * Assignment: 5
 * Assignment: Create an updated version of Team Builder Application. The updated version should have additional five events. 
 *              It should allow the user to select and book for multiple locations. The places available should keep on updating and each time the application is executed
 *              it should consider the updated availability. The application should also create a management report that stores the event, location, and the palces available for each event. 
 *              Also, there should be a file for each day that stores the transaction performed on that day and  details of the booking done.
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Team_Builder_Upgrade
{
    public partial class Form1 : Form
    {
        //Declare CurrentEventPrice, CurrentMealPrice, FinalCost, InitialFinalCost variables as decimal data type
        decimal CurrentEventPrice, CurrentMealPrice, TotalPrice, FinalCost, InitialFinalCost = 0;

        //Declare an array to read available placestocks
        int[,] ResultArray = new int[10, 5];

        //Declare PlaceStock, CountRequired, CountAvail, MealFee as interger
        int PlaceStock, CountRequired, CountAvail, MealFee;

        //Declare TransactionNumber as string
        string TransactionNumber;

        ////Declare ArrayPath as string
        string ArrayPath = "PlacesStockArray.txt";

        //Declare System Time as string
        string Time = DateTime.Now.ToString("dd_MM_yyyy");

        public Form1()
        {
            InitializeComponent();
        }

        //Create a 1-D readonly array for the Event Names
        static readonly string[] Eventname = { "Murder Mystery Weekend", "CSI Weekend", "The Great Outdoors", "The Chase", "Digital Refresh", "Action Photography", "Team Ryder Cup", "Abselling", "War Games", "Find Wally" };

        //Create a 1-D readonly array for the Event Places
        static readonly string[] EventPlace = { "Cork", "Dublin", "Galway", "Belmullet", "Belfast" };

        //Create a 1-D readonly array for for the Event Meal Options
        static readonly string[] MealOption = { "Full", "Half", "Breakfast", "None" };

        //Create a 2-D readonly array for the Pricing of events
        static readonly decimal[,] EventPricing =  {
                                                   {1100m, 930m, 1050m, 1210m, 7940m},
                                                   {1750m, 1495m, 1675m, 1915m, 1285m},
                                                   {2500m, 2160m, 2400m, 2720m, 1880m},
                                                   {3300m, 2790m, 3150m, 3630m, 2370m},
                                                   {1099m, 929m, 1049m, 1209m, 789m},
                                                   {2249m, 1824m, 2124m, 2524m, 1474m},
                                                   {1369m, 1114m, 1294m, 1534m, 904m},
                                                   {999m, 829m, 949m, 1109m, 689m},
                                                   {3499m, 2989m, 3349m, 3829m, 2569m},
                                                   {2049m, 1624m, 1924m, 2324m, 1274m},
                                                   };

        //Create a 2-D readonly array for the Meal Pricing of events
        static readonly decimal[,] MealPricing =   {
                                                   {99m, 75m, 24m, 0m},
                                                   {149m, 113m, 36m, 0m},
                                                   {198m, 150m, 48m,0m},
                                                   {297m, 225m, 72m, 0m},
                                                   {99m, 75m, 24m, 0m},
                                                   {248m, 188m, 60m, 0m},
                                                   {149m, 113m, 36m, 0m},
                                                   {99m, 75m, 24m, 0m},
                                                   {297m, 225m, 72m, 0m},
                                                   {248m, 188m, 60m, 0m},
                                                   };

        //Create a 2-D array for the No. of places available 
        static int[,] PlacesAvailablity =          {
                                                   {35, 67, 12, 77, 32},
                                                   {28, 03, 34, 12, 07},
                                                   {23, 02, 06, 04, 03},
                                                   {12, 06, 09, 04, 06},
                                                   {02, 00, 07, 05, 08},
                                                   {01, 08, 04, 07, 04},
                                                   {16, 24, 40, 04, 12},
                                                   {03, 07, 45, 03, 03},
                                                   {45, 12, 56, 12, 23},
                                                   {00, 00, 03, 00, 00},
                                                   };





        private void EventsNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EventAndPlaceCheck();
            if (EventsNameListBox.SelectedIndex != -1 && EventPlaceListBox.SelectedIndex != -1)
            {
                // Check Meal LisBox Selection
                if (MealListBox.SelectedIndex == -1)
                {
                    //if true assign value 0 to MealFee
                    MealFee = 0;

                    //And Display this Final Cost for the Selected items
                    FinalCost = EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealFee;
                }
                else
                {
                    //Display this Final Cost for the Slected Items
                    FinalCost = EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealPricing[EventsNameListBox.SelectedIndex, MealListBox.SelectedIndex];
                }
                //Display this Final Cost for the Slected Items in TotalCostDetails textBox
                TotalCostDetails.Text = FinalCost.ToString("c2");
            }
        }




        private void EventPlaceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EventAndPlaceCheck();
            if (EventsNameListBox.SelectedIndex != -1 && EventPlaceListBox.SelectedIndex != -1)
            {
                // Check Meal LisBox Selection
                if (MealListBox.SelectedIndex == -1)
                {
                    //if true assign value 0 to MealFee
                    MealFee = 0;

                    //And Display this Final Cost for the Selected items
                    FinalCost = EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealFee;
                }
                else
                {
                    //Display this Final Cost for the Slected Items
                    FinalCost = EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealPricing[EventsNameListBox.SelectedIndex, MealListBox.SelectedIndex];
                }
                //Display this Final Cost for the Slected Items in  TotalCostDetails textbox
                TotalCostDetails.Text = FinalCost.ToString("c2");
            }
        }

        private void MealListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            //EventAndPlaceCheck();
            if (MealListBox.SelectedIndex != -1 && EventsNameListBox.SelectedIndex != -1)
            {
                FinalCost = EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealPricing[EventsNameListBox.SelectedIndex, MealListBox.SelectedIndex];
                TotalCostDetails.Text = FinalCost.ToString("c2");
            }
        }


        private void AddBookingButton_Click(object sender, EventArgs e)
        {
            if (EventsNameListBox.SelectedIndex != -1 || EventPlaceListBox.SelectedIndex != -1)
           {
                //if all three listbox is selected lected event, event place
                CurrentEventPrice = EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex];

                //Similarly retrive meal price 
                CurrentMealPrice = MealPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex];

                //Read the file PlacesStocks toncheck the availability 
                RetriveArray();

                

                // BookingAvailability() is false 
                if (BookingAvailability() != false)
                {
                    // Calculate TotalPrice
                    TotalPrice = (FinalCost + InitialFinalCost);
                    
                    //Display the total cart price by adding FinalCost and InitialFinalCost
                    DisplayTotalCartPriceLabel.Text = TotalPrice.ToString("C2");

                    //Store FInalCost in Initial Cost fo the next time
                    InitialFinalCost = TotalPrice;

                    
                }
            }
            else
            {
                
                MessageBox.Show("Please Select Event Name or Event Place", "Event Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }

        private Boolean BookingAvailability()
        {
            // code for default input of number of places required
            if (PlacesRequiredTextBox.Text == "")
            {
                // default value is set to one
                PlacesRequiredTextBox.Text = "1";
                CountRequired = 1;
            }
            else
            {
                //Tickets required go in this variable
                CountRequired = int.Parse(PlacesRequiredTextBox.Text);
            }


            // if required num of tickets are less than or equal to Available tikets 
            if (PlaceStock >= CountRequired)
            {
                // calculating the places available
                CountAvail = PlaceStock - CountRequired;

                PlacesAvailablity[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] = CountAvail;

                // function to add order to listbox is called
                UpdatingConfirmationListBox();
                
                // all selections are cleared
                EventsNameListBox.SelectedItems.Clear();
                EventPlaceListBox.SelectedItems.Clear();
                MealListBox.SelectedItems.Clear();
                PlacesRequiredTextBox.Text="";
                TotalCostDetails.Text = "";

                return true;

            }
            else
            {
                // Message box displaying lack of place availablity is shown.

                MessageBox.Show("Bookings Required exceeds availability. Kindly make changes.", "Booking Unavailability", MessageBoxButtons.OK, MessageBoxIcon.Information);

               //content of the text box is selected
               PlacesRequiredTextBox.SelectAll();
                // focus is set on the textbox to change input
                PlacesRequiredTextBox.Focus();
                // Actual available places value is displayed in the textbox
                PlacesRequiredTextBox.Text = PlaceStock.ToString();
                // total cost details label is cleared
                TotalCostDetails.Text = "";

                return false;
            }
        }

        private void UpdatingConfirmationListBox()
        {
            // if case when options are added
            if (EventsNameListBox.SelectedIndex != -1 && EventPlaceListBox.SelectedIndex != -1 || MealListBox.SelectedIndex != -1)
            {
                // add event and place to cart
                CartListbox.Items.Add(Eventname[EventsNameListBox.SelectedIndex]);
                CartListbox.Items.Add(EventPlace[EventPlaceListBox.SelectedIndex]);
                if (MealListBox.SelectedIndex == -1)
                {
                    // when meals are not selected, default meals are set to no meals
                    CartListbox.Items.Add("No Meal");
                }
                else
                {
                    // when meals are selected 
                    CartListbox.Items.Add(MealOption[MealListBox.SelectedIndex]);
                }

                
                CartListbox.Items.Add(CountRequired);
                CartListbox.Items.Add("€" + FinalCost);
                CartListbox.Items.Add(" ");
               

            }
            else
            {
                //message box asking to select items is displayed
                MessageBox.Show("Select all the items", "Entry Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void PlacesRequiredTextBox_TextChanged(object sender, EventArgs e)
        {
            // when places required is changed  
            try
            {
                if (PlacesRequiredTextBox.Text != null && MealListBox.SelectedIndex != -1)
                {
                    CountRequired = int.Parse(PlacesRequiredTextBox.Text);
                    FinalCost = CountRequired * (EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealPricing[EventsNameListBox.SelectedIndex, MealListBox.SelectedIndex]);
                    TotalCostDetails.Text = FinalCost.ToString("C2");
                }
                else if(PlacesRequiredTextBox.Text != null && MealListBox.SelectedIndex == -1)
                {
                    CountRequired = int.Parse(PlacesRequiredTextBox.Text);
                    FinalCost = CountRequired * (EventPricing[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex] + MealFee);
                    TotalCostDetails.Text = FinalCost.ToString("C2");
                }
            }
            catch (Exception)
            {

               

            }
        }

        //When confirm button is clicked
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // transation number is created
            Random r = new Random();
            TransactionNumber = r.Next(0, 999999).ToString("D6");

            
            // cartlistbox items are stored to string text
            string text = "";
            foreach (var item in CartListbox.Items)
            {

                text += item.ToString() + "\n"; 
            }
            // string text is displayed is confirmation message bx

            DialogResult result = MessageBox.Show(text, "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                // when OK is pressed, order is added to booking file
                string a = "Booking" + Time + ".txt";

                Console.WriteLine("Booking" + Time + ".txt");

                if (!File.Exists(a))
                {
                    StreamWriter sw1 = File.CreateText(a);
                    sw1.Close();
                }

                StreamWriter sw = File.AppendText(a);
                sw.WriteLine(TransactionNumber);

                
                for (int Count = 0; Count < CartListbox.Items.Count; Count++)
                {
                    sw.WriteLine(CartListbox.Items[Count]);
                   
                }

               
                // booking confirmation message is displayed
                sw.Close();
                MessageBox.Show("Congratulations! Your Bookings are confirmed", "Congratulations");

                // all selections are cleared
                EventsNameListBox.SelectedItems.Clear();
                EventPlaceListBox.SelectedItems.Clear();
                MealListBox.SelectedItems.Clear();
                PlacesRequiredTextBox.Text = "";
                TotalCostDetails.Text = "";
                CartListbox.Items.Clear();
                FinalCost = 0;
                InitialFinalCost = 0;
                DisplayTotalCartPriceLabel.Text = "";
                TotalCostDetails.Text = "";

                // places available array is updated
                WriteFile();
                RetriveArray();
            

        }

            else if (result == DialogResult.Cancel)
            {

            }
            

            ManagerReport(ResultArray);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddBookingToolTip.SetToolTip(AddBookingButton, "Add order(s) to cart");
            ClearButtonToolTip.SetToolTip(ClearButton, "Clear the selected item");
            ReportButtonToolTip.SetToolTip(ManagementReportButton, "Click to view report");
            ExitButtonToolTip.SetToolTip(ExitButton, "Exit Application");
            ConfirmButtonToolTip.SetToolTip(ConfirmButton,"Click to complete the order");
        }

        private void CartListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ManagementReportButton_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "ManagementReport.txt");

        }


        // Write the Places Availability array into text file
        public void WriteFile()
        {
            
            StreamWriter WriteArray = File.CreateText(ArrayPath);
            for (int CountRows = 0; CountRows < Eventname.Length; CountRows++)
            {
                for (int CountColumns = 0; CountColumns < EventPlace.Length; CountColumns++)
                {
                    WriteArray.WriteLine(PlacesAvailablity[CountRows, CountColumns]);
                    Console.WriteLine(PlacesAvailablity[CountRows, CountColumns]);
                }
            }
            WriteArray.Close();
        }

        //Retrive the value from the text file of Places Availability
        public void RetriveArray()
        {
            StreamReader sr = File.OpenText("PlacesStockArray.txt");

            for (int row = 0; row < Eventname.Length; row++)
            {
                for (int col = 0; col < EventPlace.Length; col++)
                {
                    ResultArray[row, col] = int.Parse(sr.ReadLine());
                    Console.WriteLine(row + " " + col + " " + ResultArray[row, col]);

                }
            }
            if (EventsNameListBox.SelectedIndex != -1 && EventPlaceListBox.SelectedIndex != -1)
            {
                PlaceStock = ResultArray[EventsNameListBox.SelectedIndex, EventPlaceListBox.SelectedIndex];
                Console.WriteLine(PlaceStock);
                sr.Close();
            }
            
        
        }

        //Clear the selected items, Total Cost, Cart List Box
        private void ClearButton_Click(object sender, EventArgs e)
        {
            EventsNameListBox.SelectedItems.Clear();
            EventPlaceListBox.SelectedItems.Clear();
            MealListBox.SelectedItems.Clear();
            PlacesRequiredTextBox.Text = "";
            DisplayTotalCartPriceLabel.Text = "";
            InitialFinalCost = 0;
            FinalCost = 0;
            TotalCostDetails.Text = "";
            CartListbox.Items.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //ManagerReport(ResultArray);
            
            Application.Exit();
        }

        //Creating the Management Report
        public void ManagerReport(int[,] PassingArray)
        {

            //Empty the file if exists
            if (File.Exists("ManagementReport.txt"))
            {
                System.IO.File.WriteAllText("ManagementReport.txt", string.Empty);
            }

                if (!File.Exists("ManagementReport.txt"))
            {
                File.Create("ManagementReport.txt").Close();
            }
            StreamWriter sw = File.AppendText("ManagementReport.txt");
            sw.WriteLine(Time);

            //Create a table that shows the event place, location, places available  
            for (int x = 0; x < EventPlace.GetLength(0); x++)
            {
                sw.Write("\t" + EventPlace[x] + "      ");
            }
            sw.Write("\t" + "Places Avail");
            sw.WriteLine();
            sw.WriteLine();
            for (int rows = 0; rows < PassingArray.GetLength(0); rows++)
            {
                for (int col = 0; col < PassingArray.GetLength(1); col++)
                {
                    // Write the  to the file.                
                    sw.Write("\t" + PassingArray[rows, col] + "\t");
                }
                sw.Write("\t" + Eventname[rows]);
                sw.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
