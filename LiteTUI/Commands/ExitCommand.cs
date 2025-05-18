using LiteTUI.Commands.Base;
using LiteTUI.Core;

namespace LiteTUI.Commands
{
    public class ExitCommand : CommandBase
    {
        public ExitCommand(ApplicationContext context)
            : base(context)
        {
        }
        
        public override Task<bool> ExecuteAsync()
        {
            Context.Running = false;
            return Task.FromResult(false);
        }
    }
} 