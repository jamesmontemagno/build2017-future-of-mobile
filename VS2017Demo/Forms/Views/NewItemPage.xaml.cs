
#if __IOS__
using Forms.iOS.Helpers;
using AVFoundation;
#elif __ANDROID__
using Forms.Droid.Helpers;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Forms
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Hello Build 2017",
                Description = "Miguel is the Best!"
            };
            


            BindingContext = this;
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            Item.Text = LabelText.Text;
            Item.Description = LabelDescription.Text;
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            LocationImplementation.GetLocation((lat, lng) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Location.Text = $"{lat}, {lng}";
                });
            });

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LabelText.Text = Item.Text;
            LabelDescription.Text = Item.Description;
        }


    }
}
