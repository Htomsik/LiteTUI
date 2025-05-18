using LiteTUI.Commands;
using LiteTUI.Core;
using LiteTUI.Example.Commands;
using LiteTUI.Models;
using ApplicationContext = LiteTUI.Core.ApplicationContext;

namespace LiteTUI.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Инициализация контекста приложения
            var context = new ApplicationContext();
            
            // Создаем главное меню
            var mainMenu = new Menu { Title = "Main Menu" };
            mainMenu.Items.Add(new MenuItem("Test async command (3 sec)", new AsyncDelayCommand(context, 3000)));
            mainMenu.Items.Add(new MenuItem("Test async command (5 sec)", new AsyncDelayCommand(context, 5000)));

            mainMenu.Items.Add(new MenuItem(
                "Test info block",
                new ShowInfoCommand(context,
                    new InfoBlock("Title", "Sample content")
                    )
                )
            );
                
            mainMenu.Items.Add(new MenuItem("Exit", new ExitCommand(context)));
            
            // Создаем и запускаем приложение
            var application = new ApplicationRunner(context, mainMenu);
            await application.RunAsync();
        }
    }
}