using LiteTUI.Commands.Base;
using LiteTUI.Controls.Base;
using LiteTUI.Core;

namespace LiteTUI.Commands
{
    public class ChangeControlCommand : CommandBase<bool>
    {
        private readonly IControl _targetControl;

        public ChangeControlCommand(ApplicationContext context, IControl targetControl)
            : base(context)
        {
            _targetControl = targetControl;
        }

        public override Task<bool> ExecuteAsync()
        {
            Context.CurrentControl = _targetControl;
            return Task.FromResult(true);
        }
    }
} 