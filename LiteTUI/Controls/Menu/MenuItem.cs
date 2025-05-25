using LiteTUI.Commands.Base;

namespace LiteTUI.Controls.Menu
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
        
        public async Task ExecuteAsync()
        {
            if (IsEnabled)
                await Command.ExecuteAsync();
        }
    }
} 