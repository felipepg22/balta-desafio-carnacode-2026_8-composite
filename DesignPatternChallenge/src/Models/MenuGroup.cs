using System;
using System.Collections.Generic;

namespace DesignPatternChallenge.Models
{
    public class MenuGroup : MenuSystem
    {
        private readonly List<MenuSystem> _children = new();
        public IReadOnlyList<MenuSystem> Children => _children;

        public MenuGroup(string title, string icon = "") : base(title, icon)
        {
            
        }
      
        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

            foreach (var child in _children)
            {
                child.Render(indent + 1);
            }
        }
       
        public override int CountItems()
        {
            int count = 0;

            foreach (var child in _children)
            {
                count += child.CountItems();
            }

            return count;
        }

        public void Add(MenuSystem menuSystem)
        {
            _children.Add(menuSystem);
        }

        public void Remove(MenuSystem menuSystem)
        {
            _children.Remove(menuSystem);
        }

        public void DisableAllItems()
        {
            foreach (var child in _children)
            {
                child.IsActive = false;

                if (child is MenuGroup group)
                {
                    group.DisableAllItems();
                }
            }
        }
    }
}
