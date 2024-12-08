﻿using AquariumProject.Presenter;
using AquariumProject.Presenter.Infrastructure;
using AquariumProject.View.ConsoleMenu;
using AquariumProject.View.ConsoleMenu.Enums;
using AquariumProject.View.Infrastructure;
using System.Drawing;

namespace AquariumProject.View
{
    public class AddFishWindow
    {
        private SwitchableMenu _addMenu;

        private bool _isExitRequested;

        public AddFishWindow(LocalizationService locale, AquaristPresenter presenter, Point position) 
        { 

            var menuBuilder = new SwitchableMenuBuilder();

            foreach (var name in locale.Names) 
            {
                menuBuilder.AddItem(name, () => presenter.Add(name));
            }

            _addMenu = menuBuilder.Build(position);
        }

        public event Action Closed = delegate { };

        public void Run() 
        {
            _isExitRequested = false;

            _addMenu.Show();

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
                    _addMenu.MoveCursor(CursorMovement.Up);
                    break;

                case ConsoleKey.DownArrow:
                    _addMenu.MoveCursor(CursorMovement.Down);
                    break;

                case ConsoleKey.Enter:
                    _addMenu.Click();
                    _isExitRequested = true;
                    break;
            }
        }
    }
}