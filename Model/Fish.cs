using AquariumProject.Model.Enums;
using AquariumProject.Model.Utils;

namespace AquariumProject.Model
{
    public class Fish
    {
        public Fish(FishSpecies species, int lifetime)
        {
            Species = species;
            Age = 0;
            Lifetime = lifetime;
            IsAlive = true;
        }

        public int Age { get; private set; }
        public int Lifetime { get; }

        public bool IsAlive { get; private set; }

        public FishSpecies Species { get; }

        public event Action Died = delegate { };

        public void GetOlder()
        {
            if (IsAlive) 
            {
                Age++;

                if (TryDie())
                {
                    IsAlive = false;

                    Died.Invoke();
                }
            }
        }

        private bool TryDie()
        {
            return (float)Age / Lifetime > UserUtils.NextSingle(0.5f, 1f);
        }
    }
}
