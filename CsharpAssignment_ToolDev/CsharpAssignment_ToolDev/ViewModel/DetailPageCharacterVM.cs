using CommunityToolkit.Mvvm.ComponentModel;
using CsharpAssignment_ToolDev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment_ToolDev.ViewModel
{
    public class DetailPageCharacterVM : ObservableObject
    {
        private CharacterClass _currentCharacter;

        public DetailPageCharacterVM()
        {
            //Test initialization
            //_currentCharacter = new CharacterClass
            //{
            //    Name = "Arlecchino",
            //    Vision = "Pyro",
            //    Weapon = "Polearm",
            //    Nation = "snezhnaya"
            //};
        }

        public CharacterClass CurrentCharacter
        {
            get => _currentCharacter;
            set => SetProperty(ref _currentCharacter, value);
        }
    }
}
