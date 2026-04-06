using System;
using System.Collections.Generic;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Managers
{
    public class MenuManager
    {
        private List<MenuItem> _topLevelItems;
        private List<MenuGroup> _topLevelGroups;

        public MenuManager()
        {
            _topLevelItems = new List<MenuItem>();
            _topLevelGroups = new List<MenuGroup>();
        }

        // Problema: Precisa gerenciar dois tipos diferentes no nível raiz
        public void AddItem(MenuItem item)
        {
            _topLevelItems.Add(item);
        }

        public void AddGroup(MenuGroup group)
        {
            _topLevelGroups.Add(group);
        }

        // Problema: Renderização trata itens e grupos separadamente
        public void RenderMenu()
        {
            Console.WriteLine("=== Menu Principal ===\n");

            foreach (var item in _topLevelItems)
            {
                item.Render();
            }

            foreach (var group in _topLevelGroups)
            {
                group.Render();
            }
        }

        // Problema: Operações precisam iterar sobre ambas as coleções
        public int GetTotalItems()
        {
            int count = _topLevelItems.Count;

            foreach (var group in _topLevelGroups)
            {
                count += group.CountItems();
            }

            return count;
        }

        // Problema: Busca em toda hierarquia é complicada
        public MenuItem FindItemByUrl(string url)
        {
            foreach (var item in _topLevelItems)
            {
                if (item.Url == url)
                    return item;
            }

            foreach (var group in _topLevelGroups)
            {
                // Precisa buscar recursivamente em cada grupo
                var found = FindInGroup(group, url);
                if (found != null)
                    return found;
            }

            return null;
        }

        private MenuItem FindInGroup(MenuGroup group, string url)
        {
            foreach (var item in group.Items)
            {
                if (item.Url == url)
                    return item;
            }

            foreach (var subGroup in group.SubGroups)
            {
                var found = FindInGroup(subGroup, url);
                if (found != null)
                    return found;
            }

            return null;
        }
    }
}
