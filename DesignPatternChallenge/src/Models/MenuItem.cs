using System;

namespace DesignPatternChallenge.Models
{
    // Contexto: Sistema CMS que precisa renderizar menus complexos com múltiplos níveis
    // Alguns itens são links simples, outros são menus que contêm mais itens
    public class MenuItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }

        public MenuItem(string title, string url, string icon = "")
        {
            Title = title;
            Url = url;
            Icon = icon;
            IsActive = true;
        }

        public void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} → {Url}");
        }

        public int CountItems()
        {
            return 1;
        }
    }
}
