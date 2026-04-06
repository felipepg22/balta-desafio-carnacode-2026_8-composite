using System;

namespace DesignPatternChallenge.Models
{
    // Contexto: Sistema CMS que precisa renderizar menus complexos com múltiplos níveis
    // Alguns itens são links simples, outros são menus que contêm mais itens
    public class MenuItem : MenuSystem
    {
        public string Url { get; set; }
        
        public MenuItem(string title, string url, string icon = "") : base(title, icon)
        {
            Url = url;
        }

        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} → {Url}");
        }

        public override int CountItems()
        {
            return 1;
        }
    }
}
