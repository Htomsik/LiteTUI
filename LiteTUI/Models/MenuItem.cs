using LiteTUI.Commands.Base;

namespace LiteTUI.Models
{
    public record MenuItem
    {
        public string Text {get; set;}
        
        public ICommand Command {get; set;}
        
        public bool IsEnabled { get; set; } = true;
        
        public MenuItem(string text, ICommand command)
        {
            Text = text;
            Command = command;
        }
        
        public async Task<bool> ExecuteAsync()
        {
            if (IsEnabled)
                return await Command.ExecuteAsync();
            
            return true;
        }
    }
} 