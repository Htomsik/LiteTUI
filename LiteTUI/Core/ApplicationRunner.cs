using LiteTUI.Models;

namespace LiteTUI.Core
{
    public class ApplicationRunner
    {
        private readonly ApplicationContext _context;
        private readonly Menu _mainMenu;
        private readonly Render _renderer;
        
        public ApplicationRunner(ApplicationContext context, Menu mainMenu)
        {
            _context = context;
            _mainMenu = mainMenu;
            _renderer = new Render(context);
        }

        public async Task RunAsync()
        {
            Console.CursorVisible = false;
            
            // Set initial menu
            _context.CurrentMenu = _mainMenu;
            
            // Main application loop
            while (_context.Running)
            {
                _renderer.RenderAll();
                
                var key = Console.ReadKey(true).Key;
                bool continueLoop = true;
                
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        _context.CurrentMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        _context.CurrentMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        if (_context.CurrentMenu.SelectedItem != null)
                             _context.CurrentMenu.SelectedItem.ExecuteAsync();
                        break;
                    case ConsoleKey.Escape:
                        // If we're in a submenu and pressed Escape, return to the main menu
                        if (_context.CurrentMenu != _mainMenu)
                            _context.CurrentMenu = _mainMenu;
                        break;
                }
                
                if (!continueLoop)
                    break;
            }
            
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
} 