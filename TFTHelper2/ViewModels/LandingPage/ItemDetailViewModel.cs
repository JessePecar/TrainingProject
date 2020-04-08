using System.Collections.Generic;
using TFTHelper2.ViewModels.Base;
using TFTHelper2.Core.Models;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using Newtonsoft.Json;
using TFTHelper2.Core.Champions;
using System.Reflection;
using System.Text;
using TFTHelper2.Mobile.UI.ViewModels.Base;
using System.Windows.Input;
using TFTHelper2.Models;
using Xamarin.Essentials;

namespace TFTHelper2.Mobile.UI.ViewModels
{
    public class ItemDetailViewModel : BasePageViewModel
    {
        #region Properties

        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                RaisePropertyChanged();
            }
        }

        private List<ItemModel> _itemData;
        public List<ItemModel> ItemData
        {
            get => _itemData;
            set
            {
                _itemData = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public ItemDetailViewModel()
        {
            SetUpCommands();
            LoadPage();
        }

        #endregion

        #region Public Methods

        public void LoadPage()
        {
            ItemData = Champions.GetItems().OrderBy(e => e.Id).ToList();
            PageTitle = "Items";
        }

        #endregion

        #region Private

        private void SetUpCommands()
        {
            CanExecute = true;
        }

        #endregion

        #region Commands

        private bool _canExecute;
        public bool CanExecute
        {
            get => _canExecute;
            set
            {
                _canExecute = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CommandMethods

        
        #endregion
    }
}
