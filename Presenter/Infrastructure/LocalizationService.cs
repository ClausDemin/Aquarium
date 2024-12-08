using AquariumProject.Model.Enums;

namespace AquariumProject.Presenter.Infrastructure
{
    public class LocalizationService
    {
        private Dictionary<FishSpecies, string> _fishSpeciesLocaleNames = 
            new Dictionary<FishSpecies, string>()
            {
                {FishSpecies.Pike, "Щука"},
                {FishSpecies.Salmon, "Лосось" },
                {FishSpecies.Herring, "Сельдь" },
                {FishSpecies.Catfish, "Сом" }
            };

        private Dictionary<string, FishSpecies> _localNamesToSpecies = new();

        public LocalizationService()
        {
            foreach (var speciesNamesPair in _fishSpeciesLocaleNames) 
            {
                _localNamesToSpecies.Add(speciesNamesPair.Value, speciesNamesPair.Key);
            }
        }

        public IEnumerable<string> Names => _fishSpeciesLocaleNames.Values;

        public string GetLocalName(FishSpecies species) 
        { 
            return _fishSpeciesLocaleNames[species];
        }

        public FishSpecies GetSpecies(string localName)
        {
            if (_localNamesToSpecies.ContainsKey(localName)) 
            { 
                return _localNamesToSpecies[localName];
            }

            return FishSpecies.None;
        }
    }
}
