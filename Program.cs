using AquariumProject.Presenter;
using AquariumProject.Presenter.Infrastructure;
using AquariumProject.View;

namespace AquariumProject
{
    public static class Program
    {
        private static int s_AquariumCapacity = 10;

        static void Main(string[] args)
        {
            var localizationService = new LocalizationService();

            var mainWindow = new MainWindow(new AquaristPresenter(s_AquariumCapacity, localizationService), localizationService);

            mainWindow.Run();
        }
    }
}
