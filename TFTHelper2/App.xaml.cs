using Xamarin.Forms;
using TFTHelper2.Mobile.UI.Views.LandingPage;
using TFTHelper2.Mobile.UI.ViewModels;
using TFTHelper2.Core.Champions;
using TFTHelper2.ViewModels.Base;
using TFTHelper2.Mobile.UI.Views.MasterDetails;

namespace TFTHelper2.Mobile.UI
{
    public partial class App : Application
    {
        public static Page CurrentPage = null;
        public static BasePageViewModel CurrentPageVM = null;

        public App()
        {
            Champions.CheckForFirstTimeSetup(true);
            InitializeComponent();
            // I will instantiate all the global objects here, and then move them to a json config file somewhere.
            App.Current.MainPage = new MyMasterDetailPage();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
