using AquariumProject.View.ConsoleMenu;
using AquariumProject.View.Infrastructure;
using AquariumProject.View.Utils;
using AquariumProject.View.ConsoleMenu.Enums;
using System.Drawing;
using AquariumProject.Presenter;
using AquariumProject.Presenter.Infrastructure;

namespace AquariumProject.View
{
    public class MainWindow
    {
        private AquaristPresenter _presenter;
        private LocalizationService _localizationService;

        private SwitchableMenu _mainMenu;
        private TextBox _aquariumInfo;

        private AddFishWindow _addWindow;
        private RemoveFishWindow _removeWindow;

        private bool _isExitRequested;

        public MainWindow(AquaristPresenter presenter, LocalizationService localizationService)
        {
            var menuBuilder = new SwitchableMenuBuilder();

            menuBuilder
                .Reset()
                .AddItem("Добавить рыбу в аквариум", ShowAddWindow)
                .AddItem("Убрать рыбу из аквариума", ShowRemoveWindow)
                .AddItem("Наблюдать за рыбой", ObserveFish)
                .AddItem("Закрыть приложение", CloseApplication);

            _mainMenu = menuBuilder.Build(new Point(0, 0));

            var textBoxPosition = UIUtils.GetPositionAfter(_mainMenu);

            _aquariumInfo = new TextBox(textBoxPosition, Console.BufferWidth - textBoxPosition.X);

            _presenter = presenter;
            _localizationService = localizationService;
        }

        public void Run()
        {   
            _isExitRequested = false;

            Console.CursorVisible = false;

            Show();

            while (_isExitRequested == false)
            {
                var userInput = Console.ReadKey(true).Key;

                HandleUserInput(userInput);
            }
        }

        private void Show() 
        {
            Console.Clear();

            _mainMenu.Show();

            _aquariumInfo.UpdateText(_presenter.GetInfo());
        }

        private void HandleUserInput(ConsoleKey userInput)
        {
            switch (userInput)
            {
                case ConsoleKey.UpArrow:
                    _mainMenu.MoveCursor(CursorMovement.Up);
                    break;

                case ConsoleKey.DownArrow:
                    _mainMenu.MoveCursor(CursorMovement.Down);
                    break;

                case ConsoleKey.Enter:
                    _mainMenu.Click();
                    break;
            }
        }

        private void ObserveFish() 
        {
            _presenter.Tick();

            _aquariumInfo.UpdateText(_presenter.GetInfo());
        }

        private void CloseApplication() 
        {
            _isExitRequested = true;
        }

        private void ShowAddWindow() 
        {
            _addWindow = new AddFishWindow(_localizationService, _presenter, new Point(0, 0));
            _addWindow.Closed += Show;

            Console.Clear();

            _addWindow.Run();
        }

        private void ShowRemoveWindow()
        {
            _removeWindow = new RemoveFishWindow(_presenter, new Point(0, 0));
            _removeWindow.Closed += Show;

            Console.Clear();

            _removeWindow.Run();
        }
    }
}
