namespace LiteTUI.Core
{
    public class Render
    {
        private readonly ApplicationContext _context;
        
        public Render(ApplicationContext context)
        {
            _context = context;
            
            // Subscribe to menu changes
            _context.MenuChanged += RenderAll;
        }
        
        public void RenderAll()
        {
            Console.Clear();
            
            RenderMenuHeader();
            RenderMenuItems();
            RenderInfoBlock();
        }
        
        private void RenderMenuHeader()
        {
            var menu = _context.CurrentMenu;
            
            // Draw title
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{menu.Title.PadRight(37)}");
            Console.WriteLine($"=======================================");
            Console.ResetColor();
        }
        
        private void RenderMenuItems()
        {
            var menu = _context.CurrentMenu;
            
            for (int i = 0; i < menu.Items.Count; i++)
            {
                var item = menu.Items[i];
                string statusText = string.Empty;
                
                // Add command status if available
                if (item.Command != null && !string.IsNullOrEmpty(item.Command.State))
                {
                    statusText = $" [{item.Command.State}]";
                }
                
                // Set color based on selection and item activity
                Console.ForegroundColor = item.IsEnabled ? ConsoleColor.Gray : ConsoleColor.DarkGray;
                
                Console.Write(i == menu.SelectedIndex ? " > " : "   ");
                Console.WriteLine($"{item.Text}{statusText}");
                Console.ResetColor();
            }
        }
        
        private void RenderInfoBlock()
        {
            // Display additional information below the menu
            if (_context.InfoBlock != null && !string.IsNullOrEmpty(_context.InfoBlock.Content))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine($"{_context.InfoBlock.Title.PadRight(37)}");
                Console.WriteLine($"=======================================");
                Console.WriteLine(_context.InfoBlock.Content);
                Console.ResetColor();
            }
        }
    }
} 