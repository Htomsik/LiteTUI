namespace LiteTUI.Commands.Base
{
    public interface ICommand
    {
        Task ExecuteAsync();
        
        string State { get; }
    }
    
    public interface ICommand<T> : ICommand
    {
        new Task<T> ExecuteAsync();
        
    }
    
    public interface ITextInputCommand : ICommand<string>
    {
        public string Title { get; set; }
    }
} 