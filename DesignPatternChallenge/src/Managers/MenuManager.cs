using System;
using System.Collections.Generic;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Managers
{
    public class MenuManager
    {
        private readonly List<MenuSystem> _rootMenus;

        public MenuManager()
        {
            _rootMenus = new List<MenuSystem>();
        }

        public void Add(MenuSystem menu)
        {
            _rootMenus.Add(menu);
        }

        public void RenderMenu()
        {
            Console.WriteLine("=== Menu Principal ===\n");

            foreach (var menu in _rootMenus)
            {
                menu.Render();
            }
        }

        public int GetTotalItems()
        {
            int count = 0;

            foreach (var menu in _rootMenus)
            {
                count += menu.CountItems();
            }

            return count;
        }

        public MenuItem? FindItemByUrl(string url)
        {
            foreach (var menu in _rootMenus)
            {
                var found = FindInNode(menu, url);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        private MenuItem? FindInNode(MenuSystem menu, string url)
        {
            if (menu is MenuItem item)
            {
                return item.Url == url ? item : null;
            }

            if (menu is MenuGroup group)
            {
                foreach (var child in group.Children)
                {
                    var found = FindInNode(child, url);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }

            return null;
        }
    }
}
