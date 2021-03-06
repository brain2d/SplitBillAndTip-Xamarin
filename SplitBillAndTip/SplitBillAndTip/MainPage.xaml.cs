﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            NavigationPage.SetHasNavigationBar(this, false);
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
            clickedButton.Style = Application.Current.Resources["PeopleButtonPressed"] as Style;
            Persons = Double.Parse(clickedButton.Text);
            if (Application.Current.Resources == null)
            {

                DisplayAlert("Alert", "You have been alerted", "OK");

            }

            //set Service was not very good: "+ TipPersent + "% tips";
            PersonsOutput.Text = Persons + " People Split Bill";
            switch (clickedButton.Text) //set inactive color to other buttons
            {
                case "1":
                {
                        button2.Style=Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        button3.Style=Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        button4.Style=Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        button5.Style=Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    break;
                }
                case "2":
                {
                        button1.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        button3.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        button4.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        button5.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        break;
                }
                case "3":
                {
                    button1.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button2.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button4.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button5.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        break;
                }
                case "4":
                {
                    button1.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button2.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button3.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button5.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                        break;
                }
                case "5":
                {
                    button1.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button2.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button3.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
                    button4.Style = Application.Current.Resources["PeopleButtonNotPressed"] as Style;
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
                    TipsOutput.Text = TipPersent + "% Tip: Service Was Rather Weak";
                    star2.Image = "images/star_empty.png";
                    star3.Image = "images/star_empty.png";
                    star4.Image = "images/star_empty.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 10:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Service Was Was Ok";
                    star1.Image = "images/star_full.png";
                    star3.Image = "images/star_empty.png";
                    star4.Image = "images/star_empty.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 15:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Service Was Good!";
                    star1.Image = "images/star_full.png";
                    star2.Image = "images/star_full.png";
                    star4.Image = "images/star_empty.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 20:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Service Was Very Good!";
                    star1.Image = "images/star_full.png";
                    star2.Image = "images/star_full.png";
                    star3.Image = "images/star_full.png";
                    star5.Image = "images/star_empty.png";
                    break;
                }
                case 25:
                {
                    TipsOutput.Text = TipPersent + "% Tip: Service Was Excellent!";
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
                CheckAmount = Double.Parse(CheckInput.Text.Replace(",", "."));
                //calculate values for output:
                //CheckInput.Text.Replace(",", ".");
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
