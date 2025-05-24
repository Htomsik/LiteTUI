using LiteTUI.Controls.Menu;
using LiteTUI.Models;

namespace LiteTUI.Core
{
    public class ApplicationRunner
    {
        private readonly ApplicationContext _context;
        private readonly Menu _mainMenu;
        private readonly ApplicationRender _renderer;
        
        public ApplicationRunner(ApplicationContext context, Menu mainMenu)
        {
            _context = context;
            _mainMenu = mainMenu;
            _renderer = new ApplicationRender(context);
        }

        public async Task RunAsync()
        {
            Console.CursorVisible = false;
            
            // Set initial menu
            _context.CurrentMenu = _mainMenu;
            
            // Launch other task for only input
            var inputTask = Task.Run(ProcessInputAsync);
            
            // render task
            while (_context.Running)
            {
                _renderer.RenderAll();
                await Task.Delay(50); // Обновляем каждые 50мс
            }
            
            await inputTask;
            
            Console.Clear();
            Console.CursorVisible = true;
        }
        
        private async Task ProcessInputAsync()
        {
            while (_context.Running && _context.CurrentMenu != null)
            {
                await Task.Delay(10);
                
                if (!Console.KeyAvailable)
                    continue;
                
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        _context.CurrentMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        _context.CurrentMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        if (_context.CurrentMenu.SelectedItem == null)
                            break;
                        _= _context.CurrentMenu.SelectedItem.ExecuteAsync();
                        break;
                    case ConsoleKey.Escape:
                        // If we're in a submenu and pressed Escape, return to the main menu
                        if (_context.CurrentMenu != _mainMenu)
                            _context.CurrentMenu = _mainMenu;
                        break;
                }
            }
        }
    }
} 