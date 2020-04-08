using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Mobile.UI.ViewModels.HomePage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TFTHelper2.Mobile.UI.Views.MasterDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageDetail : ContentPage
    {
        private static HomePage _vm;
        public static MasterDetailPageDetail Instance;
        public static MasterDetailPageDetail GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new MasterDetailPageDetail();
                }
                return Instance;
            }
            set
            {
                Instance = value;
            }
        }

        public MasterDetailPageDetail()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.CurrentPage = GetInstance;
            _vm = new HomePage();
            _vm.Navigation = this.Navigation;
            BindingContext = _vm;
            _vm?.OnPageAppearing();
            _vm?.RaiseAllPropertiesChanged();

        }
    }
}
