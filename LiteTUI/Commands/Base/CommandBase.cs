using LiteTUI.Core;

namespace LiteTUI.Commands.Base
{
    public abstract class CommandBase(ApplicationContext context) : ICommand
    {
        private string _state = string.Empty;
        public string State
        {
            get => _state;
            protected set
            {
                if (_state == value) 
                    return;
                
                _state = value;
                Context.OnMenuChanged();
            }
        }
        
        protected readonly ApplicationContext Context = context;

        public abstract Task<bool> ExecuteAsync();
      
    }
} 