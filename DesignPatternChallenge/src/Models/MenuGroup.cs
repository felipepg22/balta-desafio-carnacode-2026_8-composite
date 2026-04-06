using System;
using System.Collections.Generic;
using DesignPatternChallenge.src.Models;

namespace DesignPatternChallenge.Models
{
    public class MenuGroup : MenuSystem
    {
        public List<MenuItem> Items { get; set; }
        public List<MenuGroup> SubGroups { get; set; }

        public MenuGroup(string title, string icon = "") : base(title, icon)
        {
            Items = new List<MenuItem>();
            SubGroups = new List<MenuGroup>();
        }

        // Problema: Lógica complexa para renderizar itens e subgrupos
        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

            // Precisa iterar sobre duas coleções diferentes
            foreach (var item in Items)
            {
                item.Render(indent + 1);
            }

            foreach (var subGroup in SubGroups)
            {
                subGroup.Render(indent + 1);
            }
        }

        // Problema: Contagem recursiva complexa
        public override int CountItems()
        {
            int count = 0;

            count += Items.Count;

            foreach (var subGroup in SubGroups)
            {
                count += subGroup.CountItems();
            }

            return count;
        }

        // Problema: Operações em lote exigem código duplicado
        public void DisableAllItems()
        {
            foreach (var item in Items)
            {
                item.IsActive = false;
            }

            foreach (var subGroup in SubGroups)
            {
                subGroup.DisableAllItems();
            }
        }
    }
}
