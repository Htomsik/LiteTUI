using LiteTUI.Commands.Base;
using LiteTUI.Controls.Info;
using LiteTUI.Core;

namespace LiteTUI.Commands
{
    public class ShowInfoCommand : CommandBase
    {
        private readonly InfoBlock _infoBlock;

        public ShowInfoCommand(ApplicationContext context, InfoBlock infoBlock)
            : base(context)
        {
            _infoBlock = infoBlock;
        }

        public override Task<bool> ExecuteAsync()
        {
            Context.InfoBlock = _infoBlock;
            
            return Task.FromResult(true);
        }
    }
} 