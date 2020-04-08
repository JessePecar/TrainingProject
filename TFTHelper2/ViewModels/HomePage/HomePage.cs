using System;
using System.Collections.Generic;
using TFTHelper2.Mobile.UI.Views.LandingPage;
using TFTHelper2.ViewModels.Base;
using Xamarin.Forms;

namespace TFTHelper2.Mobile.UI.ViewModels.HomePage
{
    public class HomePage : BasePageViewModel
    {
        #region Properties

        private IList<ContentView> _contentHolders = new List<ContentView>();
        public IList<ContentView> ContentHolders
        {
            get => _contentHolders;
            set
            {
                _contentHolders = value;
                RaisePropertyChanged();
            }
        }

        private int _selectedView;
        public int SelectedView
        {
            get => _selectedView;
            set
            {
                _selectedView = value;
                if (value == 0)
                {
                    PageViewResource.ContentViewTitle = "Champions";
                }
                else if (value == 1)
                {
                    PageViewResource.ContentViewTitle = "Items";
                }
                else
                {
                    PageViewResource.ContentViewTitle = "Error";
                }
                RaisePropertyChanged();
            }
        }

        #endregion
        public HomePage()
        {
            LoadViews();
        }

        #region Private Methods

        private void LoadViews()
        {
            List<ContentView> views = new List<ContentView>();
            LandingPageView lpv = new LandingPageView();
            lpv.LoadView(new LandingPageViewModel());
            ItemDetailView idv = new ItemDetailView();
            idv.LoadView(new ItemDetailViewModel());

            //This will not work if there is more than instance created for each view
            views.Add(lpv);
            views.Add(idv);
            ContentHolders = views;
        }
        #endregion
    }
}
