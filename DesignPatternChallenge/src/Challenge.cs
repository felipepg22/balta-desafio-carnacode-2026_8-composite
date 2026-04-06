// DESAFIO: Sistema de Menus Hierárquicos
// PROBLEMA: Um sistema de gestão de conteúdo precisa construir menus com itens simples e submenus aninhados
// O código atual trata itens individuais e grupos de forma diferente, complicando operações recursivas

using System;
using DesignPatternChallenge.Managers;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Menus CMS ===\n");

            var manager = new MenuManager();

            // Item simples no nível raiz
            manager.AddItem(new MenuItem("Home", "/", "🏠"));

            // Grupo com itens
            var productsMenu = new MenuGroup("Produtos", "📦");
            productsMenu.Items.Add(new MenuItem("Todos", "/produtos"));
            productsMenu.Items.Add(new MenuItem("Categorias", "/categorias"));
            productsMenu.Items.Add(new MenuItem("Ofertas", "/ofertas"));

            // Subgrupo dentro de grupo
            var clothingMenu = new MenuGroup("Roupas", "👕");
            clothingMenu.Items.Add(new MenuItem("Camisetas", "/roupas/camisetas"));
            clothingMenu.Items.Add(new MenuItem("Calças", "/roupas/calcas"));
            productsMenu.SubGroups.Add(clothingMenu);

            manager.AddGroup(productsMenu);

            // Outro grupo
            var adminMenu = new MenuGroup("Administração", "⚙️");
            adminMenu.Items.Add(new MenuItem("Usuários", "/admin/usuarios"));
            adminMenu.Items.Add(new MenuItem("Configurações", "/admin/config"));
            manager.AddGroup(adminMenu);

            manager.RenderMenu();

            Console.WriteLine($"\nTotal de itens no menu: {manager.GetTotalItems()}");

            // Problema: Buscar item requer lógica especial para navegar hierarquia
            var item = manager.FindItemByUrl("/roupas/camisetas");
            if (item != null)
            {
                Console.WriteLine($"\n✓ Item encontrado: {item.Title}");
            }

            Console.WriteLine("\n=== PROBLEMAS ===");
            Console.WriteLine("✗ MenuItem e MenuGroup são tratados de forma diferente");
            Console.WriteLine("✗ Operações recursivas requerem código duplicado");
            Console.WriteLine("✗ Cliente precisa saber se está lidando com item ou grupo");
            Console.WriteLine("✗ Adicionar nova operação = modificar ambas as classes");
            Console.WriteLine("✗ Não há interface uniforme para tratar a hierarquia");

            // Perguntas para reflexão:
            // - Como tratar itens individuais e grupos de forma uniforme?
            // - Como simplificar operações recursivas na hierarquia?
            // - Como permitir que o cliente trate toda a estrutura sem saber os detalhes?
            // - Como facilitar adicionar novas operações que percorrem a árvore?
        }
    }
}
