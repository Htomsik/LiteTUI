using LiteTUI.Core;

namespace LiteTUI.Commands.Base
{
    public abstract class CommandBase(ApplicationContext context) : ICommand
    {
        public string State { get; protected set; } = string.Empty;
        
        protected readonly ApplicationContext Context = context;

        public abstract Task<bool> ExecuteAsync();
      
    }
} 