using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Distribution_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Index variable
        int p = 0;

        //Initialize packageList
        List<Package> packageList = new List<Package>()
        {
            new Package("Z131", "O'Fallon", "IL"),
            new Package("A352", "Jefferson", "MO"),
            new Package("I420", "St. Charles", "MO"),
            new Package("H302", "Belleville", "IL"),
            new Package("F869", "Appleton", "WI"),
            new Package("E673", "Madison", "WI")
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayPackage();
        }
        void DisplayPackage()
        {
            //Displays package info
            packageNumLabel.Text = (p + 1).ToString();
            idTextBox.Text = packageList[p].PackageID;
            cityTextBox.Text = packageList[p].DestinationCity;
            stateTextBox.Text = packageList[p].DestinationState;

            //Logic for button behavior
            if (p == 0)
            {
                firstButton.Enabled = false;
                previousButton.Enabled = false;
            }
            else
            {
                firstButton.Enabled = true;
                previousButton.Enabled = true;
            }
            if (p == packageList.Count - 1)
            {
                nextButton.Enabled = false;
                lastButton.Enabled = false;
            }
            else
            {
                nextButton.Enabled = true;
                lastButton.Enabled = true;
            }
        }

        //Event handlers for each button
        private void firstButton_Click(object sender, EventArgs e)
        {
            p = 0;
            DisplayPackage();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            p -= 1;
            DisplayPackage();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            p += 1;
            DisplayPackage();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            p = packageList.Count - 1;
            DisplayPackage();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Clear results box and display search result
            resultsListBox.Items.Clear();
            string searchTerm = searchTextBox.Text.ToLower();

            //Allows for upper/lowercase searches
            //Loops through DestinationState property for each package object
            foreach (Package p in packageList)
            {
                if (searchTerm == p.DestinationState.ToLower()){
                    resultsListBox.Items.Add(p.PackageID);
                }
            }
        }

        //Event handler for a selected search result
        private void resultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displays info for selected package via PackageID property
            for (int i = 0; i < packageList.Count; i++)
            {
                if(packageList[i].PackageID == resultsListBox.SelectedItem)
                {
                    p = i;
                    DisplayPackage();
                }
            }
        }
    }
}
