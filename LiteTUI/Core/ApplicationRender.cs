using System.Text;

namespace LiteTUI.Core
{
    public class ApplicationRender
    {
        private readonly ApplicationContext _context;

        private string _previousContent = string.Empty;
        
        public ApplicationRender(ApplicationContext context)
        {
            _context = context;
        }
        
        public void RenderAll()
        {
            // Create StringBuilder to collect rendering content
            var contentBuilder = new StringBuilder();
            
            // Add content from current control
            if (_context.CurrentControl != null)
            {
                contentBuilder.Append(_context.CurrentControl.GetRenderContent());
            }
            
            // Add content from info block if present
            if (_context.InfoBlock != null)
            {
                contentBuilder.Append(_context.InfoBlock.GetRenderContent());
            }
            
            string newContent = contentBuilder.ToString();
            
            // Check if content has changed
            if (newContent == _previousContent) 
                return;
            
            // Clear console using gentle method
            ClearConsole();
                
            // Write all content at once to minimize flickering
            Console.Write(newContent);
                
            // Save current content
            _previousContent = newContent;
        }
        
        // Method to clear console without using Console.Clear()
        private void ClearConsole()
        {
            // Reset cursor to beginning
            Console.SetCursorPosition(0, 0);
            
            // Get console buffer dimensions
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            
            // Fill console with spaces
            var blankLine = new string(' ', width);
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(blankLine);
            }
            
            // Return cursor to initial position
            Console.SetCursorPosition(0, 0);
        }
    }
} 