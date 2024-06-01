using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsharpAssignment_ToolDev.Model;
using CsharpAssignment_ToolDev.Repository;
using CsharpAssignment_ToolDev.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsharpAssignment_ToolDev.ViewModel
{
    public class OverviewCharactersVM : ObservableObject
    {
        private readonly GenshinApiService _apiService;
        private List<CharacterClass> _allCharacters;
        private List<CharacterClass> _characters;
        private List<string> _characterElements;
        private string _selectedElement;
        private CharacterClass _selectedCharacter;
        private string _searchText;
        private bool _isUsingLocalData;
        private bool _isLoading;

        public List<CharacterClass> Characters
        {
            get => _characters;
            set => SetProperty(ref _characters, value);
        }

        public List<string> CharacterElements
        {
            get => _characterElements;
            set => SetProperty(ref _characterElements, value);
        }

        public string SelectedElement
        {
            get => _selectedElement;
            set
            {
                SetProperty(ref _selectedElement, value);
                FilterCharacters();
            }
        }

        public CharacterClass SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterCharacters();
            }
        }

        public bool IsUsingLocalData
        {
            get => _isUsingLocalData;
            set
            {
                SetProperty(ref _isUsingLocalData, value);
                LoadData();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand NavigateToDetailCommand { get; }

        public OverviewCharactersVM()
        {
            _apiService = new GenshinApiService();
            _isUsingLocalData = true; // Default to using local data
            NavigateToDetailCommand = new RelayCommand<CharacterClass>(NavigateToDetail);
            LoadData();
        }

        private async void LoadData()
        {
            IsLoading = true;

            if (IsUsingLocalData)
            {
                _allCharacters = GenshinCharacterRepository.GetAllCharacters();
            }
            else
            {
                _allCharacters = await _apiService.GetAllCharactersAsync();
            }

            PopulateCharacterElements();
            FilterCharacters();

            IsLoading = false;
        }

        private void PopulateCharacterElements()
        {
            var visions = _allCharacters.Select(c => c.Vision).Distinct().ToList();
            visions.Insert(0, "All");
            CharacterElements = visions;
        }

        private void FilterCharacters()
        {
            var filteredCharacters = _allCharacters.AsQueryable();

            if (!string.IsNullOrWhiteSpace(_selectedElement) && _selectedElement != "All")
            {
                filteredCharacters = filteredCharacters.Where(c => c.Vision.Equals(_selectedElement, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(_searchText))
            {
                filteredCharacters = filteredCharacters.Where(c => c.Name.StartsWith(_searchText, StringComparison.OrdinalIgnoreCase));
            }

            Characters = filteredCharacters.ToList();
        }

        private void NavigateToDetail(CharacterClass character)
        {
            if (character != null)
            {
                var detailPageViewModel = new DetailPageCharacterVM { CurrentCharacter = character };
                App.NavigationService.NavigateTo("DetailPage", detailPageViewModel);
            }
        }
    }
}