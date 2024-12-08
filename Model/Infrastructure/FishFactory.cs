using AquariumProject.Model;
using AquariumProject.Model.Enums;

namespace AquariumProject.Model.Infrastructure
{
    public class FishFactory
    {
        private static Dictionary<FishSpecies, int> s_FishLifeTime =
            new Dictionary<FishSpecies, int>()
            {
                {FishSpecies.Pike,  5},
                {FishSpecies.Salmon, 7},
                {FishSpecies.Herring, 3},
                {FishSpecies.Catfish, 10}
            };

        public Fish Create(FishSpecies species)
        {
            return new Fish(species, s_FishLifeTime[species]);
        }
    }
}
