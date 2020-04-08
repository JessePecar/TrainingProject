using System.Collections.Generic;
using TFTHelper2.ViewModels.Base;
using TFTHelper2.Core.Models;
using System.Linq;
using TFTHelper2.Core.Champions;
using TFTHelper2.Mobile.UI.ViewModels.Base;
using System.Windows.Input;
using TFTHelper2.Models;
using Xamarin.Essentials;

namespace TFTHelper2.Mobile.UI.ViewModels
{
    public class LandingPageViewModel : BaseViewModel
    {
        #region Properties

        //private List<ChampionModel> _baseChampions = new List<ChampionModel>();
        public List<ChampionModel> BaseChampions
        {
            get => Champions.GetChampions();
        }
        private List<ChampionModel> _filteredChampions = new List<ChampionModel>();
        public List<ChampionModel> FilteredChampions
        {
            get => _filteredChampions;
            set
            {
                _filteredChampions = value;
                RaisePropertyChanged();
            }
        }
        private ChampionModel _selectedChampion;
        public ChampionModel SelectedChampion
        {
            get => _selectedChampion;
            set
            {
                _selectedChampion = value;
                RaisePropertyChanged();
            }
        }
        public int ChampionsCount => BaseChampions.Count;

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

        private string _selectedSort = null;
        public string SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;
                /*
                 "Name Descending",
                 "Name Ascending",
                 "Cost Descending",
                 "Cost Ascending"
                 */
                switch (_selectedSort)
                {
                    case "Name Descending":
                        FilteredChampions = FilteredChampions.OrderByDescending(e => e.Name).ToList();
                        break;
                    case "Name Ascending":
                        FilteredChampions = FilteredChampions.OrderBy(e => e.Name).ToList();
                        break;
                    case "Cost Descending":
                        FilteredChampions = FilteredChampions.OrderByDescending(e => e.Cost).ToList();
                        break;
                    case "Cost Ascending":
                        FilteredChampions = FilteredChampions.OrderBy(e => e.Cost).ToList();
                        break;
                    default:
                        FilteredChampions = FilteredChampions.OrderBy(e => e.Name).ToList();
                        break;
                }
                RaisePropertyChanged();
            }
        }

        //private List<string> _sortSelection;
        public List<string> SortSelection
        {
            get => Champions.GetSort();
        }

        private ClassModel _selectedFilter = null;
        public ClassModel SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (value != null)
                {
                    _selectedFilter = value;
                    Vibration.Vibrate(75);
                    OnFilterSelected();
                    RaisePropertyChanged();
                }
            }
        }

        //private List<string> _filterSelection;
        public List<ClassModel> FilterSelection
        {
            get => Champions.GetClass();
        }

        private bool _isSelectingFilter;
        public bool IsSelectingFilter
        {
            get => _isSelectingFilter;
            set
            {
                _isSelectingFilter = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public LandingPageViewModel()
        {
            SetUpCommands();
            IsSelectingFilter = false;
        }

        #endregion

        #region Public Methods

        public void LoadPage()
        {
            FilteredChampions = BaseChampions;
            SelectedFilter = FilterSelection.FirstOrDefault();
            SelectedSort = SortSelection.FirstOrDefault();
            PageTitle = "Champion List";
        }

        #endregion

        #region Private

        private void SetUpCommands()
        {
            _onSelectFilterClicked = new RelayCommand(OnCmdSelectFilterClicked, () => CanExecute);
            _onOpenFilterClicked = new RelayCommand(OnOpenFilter, () => CanExecute);
            _onSelectChampionClicked = new RelayCommand(OnChampionSelected, () => CanExecute);
            _onFilterChampionClicked = new RelayCommand(OnFilterSelected, () => CanExecute);

            CanExecute = true;
        }

        private void SetFilter()
        {
            if (!string.IsNullOrEmpty(SelectedFilter?.Name))
            {
                if (SelectedFilter == FilterSelection.FirstOrDefault())
                {
                    FilteredChampions = BaseChampions;
                }
                else if (SelectedFilter.Name == "One Cost")
                {
                    FilteredChampions = BaseChampions.Where(e => e.Cost == 1).ToList();
                }
                else if (SelectedFilter.Name == "Two Cost")
                {
                    FilteredChampions = BaseChampions.Where(e => e.Cost == 2).ToList();
                }
                else if (SelectedFilter.Name == "Three Cost")
                {
                    FilteredChampions = BaseChampions.Where(e => e.Cost == 3).ToList();
                }
                else if (SelectedFilter.Name == "Four Cost")
                {
                    FilteredChampions = BaseChampions.Where(e => e.Cost == 4).ToList();
                }
                else if (SelectedFilter.Name == "Five Cost")
                {
                    FilteredChampions = BaseChampions.Where(e => e.Cost == 5).ToList();
                }
                else if (SelectedFilter.Name == "Seven Cost")
                {
                    FilteredChampions = BaseChampions.Where(e => e.Cost == 7).ToList();
                }
                else
                {
                    FilteredChampions = BaseChampions.Where(e => e.Traits.Contains(_selectedFilter.Name)).ToList();
                }
            }
            else
            {
                FilteredChampions = BaseChampions.Where(e => e.Name.Contains("c")).ToList();
            }
        }

        #endregion

        #region Commands

        private RelayCommand _onSelectFilterClicked { get; set; }
        public ICommand OnSelectFilterClicked => _onSelectFilterClicked;

        private RelayCommand _onOpenFilterClicked { get; set; }
        public ICommand OnOpenFilterClicked => _onOpenFilterClicked;

        private RelayCommand _onSelectChampionClicked { get; set; }
        public ICommand OnSelectChampionClicked => _onSelectFilterClicked;

        private RelayCommand _onFilterChampionClicked { get; set; }
        public ICommand OnFilterChampionClicked => _onFilterChampionClicked;

        private bool _canExecute;
        public bool CanExecute
        {
            get => _canExecute;
            set
            {
                _canExecute = value;
                _onSelectFilterClicked.ChangeCanExecute();
                _onSelectChampionClicked.ChangeCanExecute();
                _onFilterChampionClicked.ChangeCanExecute();
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CommandMethods

        private void OnCmdSelectFilterClicked()
        {
            CanExecute = false;
            IsSelectingFilter = !IsSelectingFilter;
            CanExecute = true;
        }
        private void OnChampionSelected()
        {
            SelectedChampion = FilteredChampions.Where(e => e.Name == "".ToString()).FirstOrDefault();
        }
        private void OnFilterSelected()
        {
            CanExecute = false;
            IsSelectingFilter = false;
            SetFilter();    
            CanExecute = true;
        }
        private void OnOpenFilter()
        {
            CanExecute = false;
            IsSelectingFilter = true;
            SetFilter();
            CanExecute = true;
        }
        #endregion
    }
}
