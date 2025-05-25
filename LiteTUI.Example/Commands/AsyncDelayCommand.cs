using LiteTUI.Commands.Base;
using LiteTUI.Core;

namespace LiteTUI.Example.Commands
{
    public class AsyncDelayCommand : CommandBase<bool>
    {
        private readonly int _delayMs;
        
        public AsyncDelayCommand(ApplicationContext context, int delayMs = 3000) 
            : base(context)
        {
            _delayMs = delayMs;
        }
        
        public override async Task<bool> ExecuteAsync()
        {
            // Reset status before starting
            State = "0%";
            
            // Display execution progress
            for (int i = 0; i <= 10; i++)
            {
                // Update status
                int percent = i * 10;
                State = $"{percent}%";
                
                // Wait specified time
                await Task.Delay(_delayMs / 10);
            }
            
            // Set completion status
            State = "Completed";
            
            await Task.Delay(1000); // Small delay to let user see the "Completed" status
            
            // Reset status after completion
            State = string.Empty;
            
            return true;
        }
    }
} 