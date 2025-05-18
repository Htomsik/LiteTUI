namespace LiteTUI.Commands.Base
{
    public interface ICommand
    {
        // Returns true to continue execution loop, false to exit
        Task<bool> ExecuteAsync();
        
        // Command execution status (will be displayed in the menu)
        string State { get; }
    }
} 