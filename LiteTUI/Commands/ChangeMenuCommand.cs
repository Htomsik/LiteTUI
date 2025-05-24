using LiteTUI.Commands.Base;
using LiteTUI.Controls.Menu;
using LiteTUI.Core;
using LiteTUI.Models;

namespace LiteTUI.Commands
{
    public class ChangeMenuCommand : CommandBase
    {
        private readonly Menu _targetMenu;

        public ChangeMenuCommand(ApplicationContext context, Menu targetMenu)
            : base(context)
        {
            _targetMenu = targetMenu;
        }

        public override Task<bool> ExecuteAsync()
        {
            Context.CurrentMenu = _targetMenu;
            return Task.FromResult(true);
        }
    }
} 