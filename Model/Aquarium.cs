namespace AquariumProject.Model
{
    public class Aquarium
    {
        private Fish[] _fish;

        public Aquarium(int capacity)
        {
            Capacity = capacity;
            Count = 0;

            _fish = new Fish[Capacity];
        }

        public int Capacity { get; }
        public int Count { get; private set; }

        public IEnumerable<Fish> Fish => _fish;

        public void Tick() 
        {
            if (Count > 0) 
            {
                foreach (var fish in _fish.Where(fish => fish != null && fish.IsAlive)) 
                { 
                    fish.GetOlder();
                }
            }
        }

        public bool TryAdd(Fish fish)
        {
            if (Count < Capacity)
            {
                _fish[Count] = fish;

                Count++;

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
                    _fish[fishIndex] = null;

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public bool TryRemove(int index)
        {
            if (index >= 0 && index <= Count)
            {
                if (_fish[index] != null)
                {
                    _fish[index] = null;

                    Count--;

                    MoveToLeft(index);

                    return true;
                }
            }

            return false;
        }

        private void MoveToLeft(int from, int step = 1) 
        {
            var buffer = _fish[from];

            for (int i = from; i < Count; i++) 
            {
                _fish[i] = _fish[i + step];
            }

            _fish[Count] = buffer;
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
