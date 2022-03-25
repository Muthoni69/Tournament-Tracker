﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void prizeAmountValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void placeNumberValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {

        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);

                foreach(IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }

                //Clears form after form validation 
                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;

            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if(placeNumberValidNumber == false)
            {
                output = false;
            }
            if(placeNumber < 1)
            {
                output = false;
            }
            if(placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if(prizeAmountValid || prizePercentageValid == false)
            {
                output = false;
            }
            if(prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            if(prizeAmount < 0 || prizePercentage > 100)
            {
                output = false;
            }




            return output;
        }
    }
}
