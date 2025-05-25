using LiteTUI.Commands;
using LiteTUI.Controls.Info;
using LiteTUI.Controls.Menu;
using LiteTUI.Core;
using LiteTUI.Example.Commands;
using LiteTUI.Example.Services;
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
            mainMenu.Items.Add(new MenuItem("Async command (3 sec)", new AsyncDelayCommand(context, 3000)));
            mainMenu.Items.Add(new MenuItem("Async command (5 sec)", new AsyncDelayCommand(context, 5000)));
            mainMenu.Items.Add(new MenuItem(
                "Info Block",
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
                new ChangeControlCommand(context, mainMenu)  // back command
            );
            
            // Add item for navigating to selection menu
            mainMenu.Items.Add(new MenuItem(
                "Selection Menu",
                new ChangeControlCommand(context, selectionMenu)
            ));
            
            // Simple Service using input control
            var textCommand = new TextInputCommand(context);
            textCommand.Title = "Input some text";
            mainMenu.Items.Add(new MenuItem(
                "Text input",
                textCommand
            ));
            
            // Simple Service using input control
            var authService = new AuthorizationService(context, new TextInputCommand(context));
            mainMenu.Items.Add(new MenuItem(
                "Authorization with Text input",
                new AuthorizeCommand(context, authService)
            ));
            
            mainMenu.Items.Add(new MenuItem("Exit", new ExitCommand(context)));
            
            // Create and run application
            var application = new ApplicationRunner(context, mainMenu);
            await application.RunAsync();
        }
    }
}