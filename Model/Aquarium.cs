namespace AquariumProject.Model
{
    public class Aquarium
    {
        private List<Fish> _fish;

        public Aquarium(int capacity)
        {
            Capacity = capacity;

            _fish = new ();
        }

        public int Capacity { get; }
        public int Count => _fish.Count;

        public IEnumerable<Fish> Fish => _fish;

        public void Tick() 
        {
            if (Count > 0) 
            {
                foreach (var fish in _fish.Where(fish => fish != null && fish.IsAlive)) 
                { 
                    fish.GrowOlder();
                }
            }
        }

        public bool TryAdd(Fish fish)
        {
            if (Count < Capacity)
            {
                _fish.Add(fish);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRemove(Fish fish)
        {
            if (Count > 0)
            {
                int fishIndex = GetFishIndex(fish);

                if (fishIndex >= 0)
                {
                    _fish.RemoveAt(fishIndex);

                    return true;
                }
            }

            return false;
        }

        public bool TryRemove(int index)
        {
            if (index >= 0 && index <= Count)
            {
                _fish.RemoveAt(index);

                return true;
            }

            return false;
        }

        private int GetFishIndex(Fish fish)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (_fish[i] == fish)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
