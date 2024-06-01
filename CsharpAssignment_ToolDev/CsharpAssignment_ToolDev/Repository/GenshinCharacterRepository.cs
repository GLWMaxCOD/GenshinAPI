using CsharpAssignment_ToolDev.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment_ToolDev.Repository
{
    public static class GenshinCharacterRepository
    {
        private static List<CharacterClass> _characters;

        public static List<CharacterClass> GetAllCharacters()
        {
            if (_characters != null)
            {
                return _characters;
            }

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CsharpAssignment_ToolDev.Resources.Data.CharactersTest.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer serializer = new JsonSerializer();
                _characters = serializer.Deserialize<List<CharacterClass>>(jsonReader);
            }

            return _characters;
        }

        public static List<string> GetCharactersVisions()
        {
            var allCharacters = GetAllCharacters();
            return allCharacters.Select(character => character.Vision).Distinct().ToList();
        }

        public static List<CharacterClass> GetAllCharacters(string visionType)
        {
            var allCharacters = GetAllCharacters();
            return allCharacters.Where(character => character.Vision.Equals(visionType, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
