using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpAssignment_ToolDev.Model;
using Newtonsoft.Json;

namespace CsharpAssignment_ToolDev.Service
{
    public class GenshinApiService
    {
        private readonly HttpClient _httpClient;

        public GenshinApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CharacterClass>> GetAllCharactersAsync()
        {
            var url = "https://genshin.jmp.blue/characters";
            var response = await _httpClient.GetStringAsync(url);
            var characterIds = JsonConvert.DeserializeObject<List<string>>(response);

            var characters = new List<CharacterClass>();
            foreach (var id in characterIds)
            {
                var character = await GetCharacterByIdAsync(id);
                if (character != null)
                {
                    characters.Add(character);
                }
            }

            return characters;
        }

        public async Task<CharacterClass> GetCharacterByIdAsync(string id)
        {
            var url = $"https://genshin.jmp.blue/characters/{id}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<CharacterClass>(response);
        }
    }
}
