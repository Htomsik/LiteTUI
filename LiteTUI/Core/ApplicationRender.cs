
namespace LiteTUI.Core
{
    public class ApplicationRender
    {
        private readonly ApplicationContext _context;
        
        public ApplicationRender(ApplicationContext context)
        {
            _context = context;
        }
        
        public void RenderAll()
        {
            Console.Clear();
            
            // Render the current control
            if (_context.CurrentControl != null)
            {
                _context.CurrentControl.Render();
            }
            
            // Render info block if present
            if (_context.InfoBlock != null)
            {
                _context.InfoBlock.Render();
            }
        }
    }
} 