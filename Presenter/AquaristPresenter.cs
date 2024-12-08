using AquariumProject.Model;
using AquariumProject.Model.Infrastructure;
using AquariumProject.Presenter.Infrastructure;

namespace AquariumProject.Presenter
{
    public class AquaristPresenter
    {
        private Aquarist _aquarist;
        private LocalizationService _localizationService;

        public AquaristPresenter(int aquariumCapacity, LocalizationService service) 
        {
            _aquarist = new Aquarist(new Aquarium(aquariumCapacity), new FishFactory());
            _localizationService = service;
        }

        public void Add(string fishName) 
        {
            var species = _localizationService.GetSpecies(fishName);

            _aquarist.AddFish(species);
        }

        public void Remove(int index) 
        {
            _aquarist.RemoveFish(index);
        }

        public void Observe() 
        { 
            _aquarist.ObserveFish();
        }

        public string[] GetInfo() 
        {
            var result = new List<string>();

            foreach (var info in _aquarist.FishInfo) 
            {
                result.Add(ParseFishInfo(info));
            }

            return result.ToArray();
        }

        private string ParseFishInfo(FishInfo info) 
        { 
            string result = string.Empty;

            result += $"Рыба {_localizationService.GetLocalName(info.Species)}";

            if (info.IsAlive)
            {
                result += $" Возраст: {info.Age}, максимальная продолжительность жизни: {info.Lifetime}";
            }
            else 
            {
                result += $" - мертва.";
            }

            return result;
        }
    }
}
