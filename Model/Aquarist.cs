using AquariumProject.Model.Enums;
using AquariumProject.Model.Infrastructure;

namespace AquariumProject.Model
{
    public class Aquarist
    {
        private Aquarium _aquarium;
        private FishFactory _fishFactory;

        public Aquarist(Aquarium aquarium, FishFactory factory)
        {
            _aquarium = aquarium;
            _fishFactory = factory;
        }

        public IEnumerable<FishInfo> FishInfo => GetFishInfo();

        public void AddFish(FishSpecies species)
        {
            _aquarium.TryAdd(_fishFactory.Create(species));
        }

        public void RemoveFish(int index)
        {
            _aquarium.TryRemove(index);
        }

        public void Tick()
        {
            _aquarium.Tick();
        }

        private IEnumerable<FishInfo> GetFishInfo()
        {
            foreach (var fish in _aquarium.Fish.Where(fish => fish != null))
            {
                yield return new FishInfo(fish.Species, fish.Age, fish.Lifetime, fish.IsAlive);
            }

            yield break;
        }
    }
}
