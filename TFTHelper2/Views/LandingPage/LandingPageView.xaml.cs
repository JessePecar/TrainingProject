using System;
using System.Collections.Generic;
using TFTHelper2.Mobile.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TFTHelper2.Mobile.UI.Views.LandingPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPageView : ContentView
    {
        private LandingPageViewModel _vm = null;
        public LandingPageView()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void LoadView(LandingPageViewModel viewModel)
        {
            _vm = viewModel;
            
            BindingContext = _vm;
            _vm.LoadPage();
            _vm.RaiseAllPropertiesChanged();
        }
    }
}
