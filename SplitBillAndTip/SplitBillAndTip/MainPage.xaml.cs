using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SplitBillAndTip
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            // создаем текстовую метку
            Label actionLabel = new Label() { FontSize = 28 };
            actionLabel.TextColor = Color.Red;
            #if WINDOWS_PHONE || WINDOWS_UWP
                        actionLabel.Text = "WINDOWS_UWP";
                        actionLabel.TextColor = Color.Blue;
            #elif __ANDROID__
                        actionLabel.Text = "ANDROID";
                        actionLabel.TextColor = Color.Red;
            #elif __IOS__
                                        actionLabel.Text = "iOS";
                                        actionLabel.TextColor = Color.Green;
            #endif
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string text = Enter_name_input.Text;
            Output_label.Text = "Hello, " + text;

        }
    }
}
