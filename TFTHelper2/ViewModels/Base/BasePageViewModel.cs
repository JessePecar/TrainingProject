using System;
using TFTHelper2.Mobile.UI;
using TFTHelper2.ViewModels.GlobalResources;

namespace TFTHelper2.ViewModels.Base
{
    public class BasePageViewModel : BaseViewModel
    {
        private ViewResource _pageViewResource = new ViewResource();
        public ViewResource PageViewResource
        {
            get
            {
                return _pageViewResource;
            }
            set
            {
                _pageViewResource = value;
                RaisePropertyChanged();
            }
        }
        public virtual void OnPageAppearing()
        {
            App.CurrentPageVM = this;

            RaiseAllPropertiesChanged();
        }
    }
}
