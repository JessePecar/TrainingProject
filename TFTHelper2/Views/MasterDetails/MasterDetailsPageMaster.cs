using System;

using Xamarin.Forms;

namespace TFTHelper2.Mobile.UI.Views.MasterDetails
{
    public class MasterDetailsPageMaster : ContentPage
    {
        public MasterDetailsPageMaster()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

