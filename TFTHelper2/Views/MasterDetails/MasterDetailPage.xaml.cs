using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTHelper2.Mobile.UI.ViewModels.MasterDetails;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TFTHelper2.Mobile.UI.Views.MasterDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMasterDetailPage : MasterDetailPage
    {
        public MyMasterDetailPage()
        {
            InitializeComponent();
        }
    }
}
