using System;
using System.Collections.Generic;
using TFTHelper2.Mobile.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TFTHelper2.Mobile.UI.Views.LandingPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailView : ContentView
    {
        private ItemDetailViewModel _vm = null;
        
        public ItemDetailView()
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
        public void LoadView(ItemDetailViewModel viewModel)
        {
            
            _vm = viewModel;
            this.BindingContext = _vm;
            _vm.RaiseAllPropertiesChanged();
        }
    }
}
