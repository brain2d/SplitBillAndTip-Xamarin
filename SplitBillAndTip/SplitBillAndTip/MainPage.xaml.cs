using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplitBillAndTip
{
	public partial class MainPage : ContentPage
	{
	    public MainPage()
	    {
	        InitializeComponent();
	    }



	    public double Persons;
	    public double TipPersent;
	    public double CheckAmount;

        public double TotalToPay;

        public double TotalTip;
        public double TotalPerPerson;
        public double TipPerPerson;
	
        private void Persons_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            switch (clickedButton.Text) //set inactive color to other buttons
            {
                case "1":
                {
                        button2.BackgroundColor = Color.White;
                        button3.BackgroundColor = Color.White;
                        button4.BackgroundColor = Color.White;
                        button5.BackgroundColor = Color.White;
                        break;
                }
                case "2":
                    {
                        button1.BackgroundColor = Color.White;
                        button3.BackgroundColor = Color.White;
                        button4.BackgroundColor = Color.White;
                        button5.BackgroundColor = Color.White;
                        break;
                    }
                case "3":
                    {
                        button1.BackgroundColor = Color.White;
                        button2.BackgroundColor = Color.White;
                        button4.BackgroundColor = Color.White;
                        button5.BackgroundColor = Color.White;
                        break;
                    }
                case "4":
                    {
                        button1.BackgroundColor = Color.White;
                        button2.BackgroundColor = Color.White;
                        button3.BackgroundColor = Color.White;
                        button5.BackgroundColor = Color.White;
                        break;
                    }
                case "5":
                    {
                        button1.BackgroundColor = Color.White;
                        button2.BackgroundColor = Color.White;
                        button3.BackgroundColor = Color.White;
                        button4.BackgroundColor = Color.White;
                        break;
                    }
            };
            clickedButton.BackgroundColor = Color.Teal;
            Persons = Double.Parse(clickedButton.Text); //set double Person
        }
        
        
        private void Button_Clicked(object sender, EventArgs e)
        {
     

            //inputs
            // Persons = Double.Parse(PersonsInput.Text);
            TipPersent = Double.Parse(TipInput.Text);
            CheckAmount = Double.Parse(CheckInput.Text);
            //calculate:
            TotalToPay = CheckAmount + CheckAmount * (TipPersent / 100);
            TotalTip = CheckAmount * (TipPersent / 100);
            TotalPerPerson = TotalToPay / Persons;
            TipPerPerson = TotalTip / Persons;

            TotalToPayLabel.Text = TotalToPay.ToString("C");
            TotalTipLabel.Text = TotalTip.ToString("C");
            TotalPerPersonLabel.Text = TotalPerPerson.ToString("C");
            TipPerPersonLabel.Text = TipPerPerson.ToString("C");
        }
    }
}
