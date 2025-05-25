using LiteTUI.Controls.Base;

namespace LiteTUI.Core
{
    public class ApplicationRunner
    {
        private readonly ApplicationContext _context;
        private readonly IControl _mainControl;
        private readonly ApplicationRender _renderer;
        
        public ApplicationRunner(ApplicationContext context, IControl mainControl)
        {
            _context = context;
            _mainControl = mainControl;
            _renderer = new ApplicationRender(context);
        }

        public async Task RunAsync()
        {
            Console.CursorVisible = false;
            
            // Set initial control
            _context.CurrentControl = _mainControl;
            
            // Launch other task for only input
            var inputTask = Task.Run(ProcessInputAsync);
            
            // render task
            while (_context.Running)
            {
                _renderer.RenderAll();
                await Task.Delay(50); // Update every 50ms
            }
            
            await inputTask;
            
            Console.Clear();
            Console.CursorVisible = true;
        }
        
        private async Task ProcessInputAsync()
        {
            while (_context.Running && _context.CurrentControl != null)
            {
                await Task.Delay(10);
                
                if (!Console.KeyAvailable)
                    continue;
                
                var key = Console.ReadKey(true).Key;
                
                // Let the control handle the key press
                _context.CurrentControl.HandleKey(key);
            }
        }
    }
} 