using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorUI
{
    public partial class PriceMatchInfo : Form
    {
        public PriceMatchInfo()
        {
            InitializeComponent();
            FreightToMidamTextBox.Text = "0";
            FreightFromMidamTextBox.Text = "0";
            CompetitorFreightTextBox.Text = "0";
            
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                TestCalculator.PriceMatch match = new TestCalculator.PriceMatch();
                TestCalculator.Operator op = new TestCalculator.Operator(1, OperatorNumberTextBox.Text, double.Parse(ListPriceTextBox.Text), double.Parse(FreightToMidamTextBox.Text));
                Flyer30TextBox.Text = op.OpListPriceUsd30.ToString();
                Flyer43TextBox.Text = op.OpListPriceUsd43.ToString();
                Flyer55TextBox.Text = op.OpListPriceUsd55.ToString();
                CostTextBox.Text = op.Cost.ToString();
                match.PriceToMatch = double.Parse(PriceToMatchTextBox.Text);
                TotalLandingCostTextBox.Text = op.LandingCost.ToString();
                match.FreightFromCompetitorToCustomer = double.Parse(CompetitorFreightTextBox.Text);
                match.FreightFromMidamToCustomer = double.Parse(FreightFromMidamTextBox.Text);
                LandingSellPriceAtCustomerTextBox.Text = match.CalculateCustomerCostWithFreight(double.Parse(PriceToMatchTextBox.Text), double.Parse(CompetitorFreightTextBox.Text)).ToString();
                FinalPriceToMatchTextBox.Text = match.CalculateMidamPriceToMatchWithFreightToCustomer(double.Parse(LandingSellPriceAtCustomerTextBox.Text), double.Parse(FreightFromMidamTextBox.Text)).ToString();
                RecommendedFlyerTextBox.Text = match.FlyerMatch(double.Parse(FinalPriceToMatchTextBox.Text), double.Parse(Flyer30TextBox.Text), double.Parse(Flyer43TextBox.Text), double.Parse(Flyer55TextBox.Text));
            }
            catch (Exception)
            {
                //TODO add a check to see if all the yellow field are filled. Maybe a while loop that checks if the background color is yellow and textbox.text has a value?
                MessageBox.Show("Please fill out all the yellow field","Information is missing");
                
            }
            

        }
    }
}
