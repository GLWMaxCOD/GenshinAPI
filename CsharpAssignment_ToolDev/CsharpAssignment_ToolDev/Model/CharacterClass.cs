using Newtonsoft.Json;
using CsharpAssignment_ToolDev.JsonConverters;
using System.Collections.Generic;

namespace CsharpAssignment_ToolDev.Model
{
    public class CharacterClass
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Vision { get; set; }
        public string Weapon { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        public string Affiliation { get; set; }
        public string SpecialDish { get; set; }
        public int Rarity { get; set; }
        public string Release { get; set; } // Keeping this as string for simplicity
        public string Constellation { get; set; }

        [JsonConverter(typeof(BirthdayConverter))]
        public string Birthday { get; set; }

        public string Description { get; set; }
        public List<SkillTalent> SkillTalents { get; set; }
        public List<PassiveTalent> PassiveTalents { get; set; }
        public List<Constellation> Constellations { get; set; }
    }

    public class SkillTalent
    {
        public string Name { get; set; }
        public string Unlock { get; set; }
        public string Description { get; set; }
        public List<Upgrade> Upgrades { get; set; }
        public string Type { get; set; }
    }

    public class PassiveTalent
    {
        public string Name { get; set; }
        public string Unlock { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
    }

    public class Constellation
    {
        public string Name { get; set; }
        public string Unlock { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
    }

    public class Upgrade
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}