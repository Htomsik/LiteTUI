using LiteTUI.Commands;
using LiteTUI.Controls.Menu;
using LiteTUI.Core;
using LiteTUI.Example.Commands;
using LiteTUI.Models;
using LiteTUI.Services;
using ApplicationContext = LiteTUI.Core.ApplicationContext;

namespace LiteTUI.Example
{
    class Program
    {
        // Simple data class for example
        class Fruit(string name)
        {
            public string Name { get; } = name;
        }
        
        static async Task Main(string[] args)
        {
            // Initialize application context
            var context = new ApplicationContext();
            
            // Create main menu
            var mainMenu = new Menu("Main Menu");
            mainMenu.Items.Add(new MenuItem("Test async command (3 sec)", new AsyncDelayCommand(context, 3000)));
            mainMenu.Items.Add(new MenuItem("Test async command (5 sec)", new AsyncDelayCommand(context, 5000)));
            mainMenu.Items.Add(new MenuItem(
                "Test info block",
                new ShowInfoCommand(context,
                    new InfoBlock("Title", "Sample content")
                    )
                )
            );
            
            // Create test data for SelectionMenu
            var fruits = new List<Fruit>
            {
                new Fruit("Apple"),
                new Fruit("Banana"),
                new Fruit( "Orange")
            };
            
            // Create selection service with our data
            var selectionService = new SelectionService<Fruit>(fruits);
            
            // Create selection menu
            var selectionMenu = new MenuSelection<Fruit>(
                context,
                selectionService,
                "Select Fruits",
                item => item.Name,  // function to get item text
                new ChangeMenuCommand(context, mainMenu)  // back command
            );
            
            // Add item for navigating to selection menu
            mainMenu.Items.Add(new MenuItem(
                "Go to selection menu",
                new ChangeMenuCommand(context, selectionMenu)
            ));
            
            mainMenu.Items.Add(new MenuItem("Exit", new ExitCommand(context)));
            
            // Create and run application
            var application = new ApplicationRunner(context, mainMenu);
            await application.RunAsync();
        }
    }
}