using LiteTUI.Core;

namespace LiteTUI.Commands.Base
{
    public abstract class CommandBase<T>(ApplicationContext context) : ICommand<T>
    {
        public string State { get; protected set; } = string.Empty;
        
        protected readonly ApplicationContext Context = context;
        
        public abstract Task<T> ExecuteAsync();
        
        Task ICommand.ExecuteAsync()
        {
            return ExecuteAsync();
        }
    }
} 