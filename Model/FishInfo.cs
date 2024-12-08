using AquariumProject.Model.Enums;

namespace AquariumProject.Model
{
    public class FishInfo
    {
        public FishInfo(FishSpecies species, int age, int lifetime, bool isAlive) 
        { 
            Species = species;
            Age = age;
            Lifetime = lifetime;
            IsAlive = isAlive;
        }

        public FishSpecies Species { get; }
        public int Age { get; }
        public int Lifetime { get; }
        public bool IsAlive { get; private set; }
    }
}
