using LiteTUI.Commands.Base;

namespace LiteTUI.Models
{
    public record MenuItem(string Text, ICommand Command)
    {
        public bool IsEnabled { get; set; } = true;
        
        public async Task<bool> ExecuteAsync()
        {
            if (IsEnabled)
                return await Command.ExecuteAsync();
            
            return true;
        }
    }
} 