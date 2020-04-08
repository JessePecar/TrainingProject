
using System;
using System.Collections.ObjectModel;
using TFTHelper2.Mobile.UI.Views.MasterDetails;
using TFTHelper2.ViewModels.Base;

namespace TFTHelper2.Mobile.UI.ViewModels.MasterDetails
{
    class MasterDetailPageViewMasterViewModel : BaseViewModel
    {
        
        public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

        public MasterDetailPageViewMasterViewModel()
        {
            MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
            {
                    new MasterDetailPageMenuItem { Id = 0, Title = "Game Details" },
                    new MasterDetailPageMenuItem { Id = 1, Title = "Team Builder" },
                    new MasterDetailPageMenuItem { Id = 2, Title = "Strategies" },
                    new MasterDetailPageMenuItem { Id = 3, Title = "Settings" }
                });     
        }
    }


    public class MasterDetailPageMenuItem
    {
        public MasterDetailPageMenuItem()
        {
            TargetType = typeof(MasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
