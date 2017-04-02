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
            currency.Text = System.Globalization.RegionInfo.CurrentRegion.CurrencySymbol;
        }
        public double Persons = 3;
        public double TipPersent = 10;
        public double CheckAmount = 0;
        public double TotalToPay;
        public double TotalTip;
        public double TotalPerPerson;
        public double TipPerPerson;
        //Person clicked
        private void Persons_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            clickedButton.BackgroundColor = Color.Yellow;
            Persons = Double.Parse(clickedButton.Text);
            //set Servise was not very good: "+ TipPersent + "% tips";
            PersonsOutput.Text = Persons + " People Split Bill";
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
            Button_Clicked(this,e);
        }
        //Star clicked
        private void Star_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            TipPersent = Double.Parse(clickedButton.ClassId); //set double Person
            clickedButton.Image = "images/star_full.png";
            switch (Convert.ToInt32(TipPersent)) //set inactive color to other buttons
            {
                case 5:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Servise Was Not Very Good";
                    star2.Image = "images/star_empty.png";
                    star3.Image = "images/star_empty.png";
                    star4.Image = "images/star_empty.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 10:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Servise Was Was Ok";
                    star1.Image = "images/star_full.png";
                    star3.Image = "images/star_empty.png";
                    star4.Image = "images/star_empty.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 15:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Servise Was Good!";
                    star1.Image = "images/star_full.png";
                    star2.Image = "images/star_full.png";
                    star4.Image = "images/star_empty.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 20:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Servise Was Very Good!";
                    star1.Image = "images/star_full.png";
                    star2.Image = "images/star_full.png";
                    star3.Image = "images/star_full.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 25:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Servise Was Excellent!";
                    star1.Image = "images/star_full.png";
                    star2.Image = "images/star_full.png";
                    star3.Image = "images/star_full.png";
                    star4.Image = "images/star_full.png";
                    break;
                }
            };
            Button_Clicked(this,e);
        }
    //Calculate
        private void Button_Clicked(object sender, EventArgs e)
        {
            double number;
            if (Double.TryParse(CheckInput.Text, out number))
            {
                CheckAmount = Double.Parse(CheckInput.Text);
                //calculate values for output:
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
}
