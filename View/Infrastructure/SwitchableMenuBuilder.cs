using AquariumProject.View.ConsoleMenu;
using System.Drawing;

namespace AquariumProject.View.Infrastructure
{
    public class SwitchableMenuBuilder
    {
        private List<MenuItem> _items = new List<MenuItem>();

        public SwitchableMenuBuilder Reset() 
        { 
            _items.Clear();

            return this;
        }

        public SwitchableMenuBuilder AddItem(string text, Action handler) 
        { 
            var menuItem = new MenuItem(text);

            menuItem.OnClick += handler;

            _items.Add(menuItem);

            return this;
        }

        public SwitchableMenu Build(Point position) 
        {
            return new SwitchableMenu(position, _items);
        }
    }
}
