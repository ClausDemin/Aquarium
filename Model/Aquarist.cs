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
            if (_aquarium.TryAdd(_fishFactory.Create(species))) 
            {
                Tick();
            }
        }

        public void RemoveFish(int index)
        {
            if (_aquarium.TryRemove(index)) 
            {
                Tick();
            }
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
