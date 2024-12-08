using AquariumProject.Presenter;
using AquariumProject.View.ConsoleMenu;
using AquariumProject.View.ConsoleMenu.Enums;
using AquariumProject.View.Infrastructure;
using System.Drawing;

namespace AquariumProject.View
{
    public class RemoveFishWindow
    {
        private SwitchableMenu _removeMenu;
        private AquaristPresenter _presenter;

        private bool _isExitRequested;

        public RemoveFishWindow(AquaristPresenter presenter, Point position) 
        { 
            _presenter = presenter;

            var menuBuilder = new SwitchableMenuBuilder();

            menuBuilder.Reset();

            foreach (var fishInfo in _presenter.GetInfo()) 
            {
                menuBuilder.AddItem(fishInfo, () => presenter.Remove(_removeMenu.GetCurrentItemIndex()));
            }

            menuBuilder.AddItem("Вернуться в главное меню", null);

            _removeMenu = menuBuilder.Build(position);
        }

        public event Action Closed = delegate { };

        public void Run() 
        { 
            _removeMenu.Show();

            _isExitRequested = false;

            while (_isExitRequested == false) 
            {
                var userInput = Console.ReadKey(true).Key;

                HandleUserInput(userInput);
            }

            Closed.Invoke();
        }

        private void HandleUserInput(ConsoleKey userInput)
        {
            switch (userInput)
            {
                case ConsoleKey.UpArrow:
                    _removeMenu.MoveCursor(CursorMovement.Up);
                    break;

                case ConsoleKey.DownArrow:
                    _removeMenu.MoveCursor(CursorMovement.Down);
                    break;

                case ConsoleKey.Enter:
                    _removeMenu.Click();
                    _isExitRequested = true;
                    break;
            }
        }
    }
}
