using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TFTHelper2.Mobile.UI.Views.MasterDetails
{
    public partial class MasterDetailPageMaster : ContentPage
    {
        private static ViewModels.MasterDetails.MasterDetailPageViewMasterViewModel _vm;

        public MasterDetailPageMaster()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm = new ViewModels.MasterDetails.MasterDetailPageViewMasterViewModel();

            if(_vm != null) BindingContext = _vm;
        }
    }
}
