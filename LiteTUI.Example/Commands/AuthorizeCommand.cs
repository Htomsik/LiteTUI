using LiteTUI.Commands.Base;
using LiteTUI.Core;
using LiteTUI.Example.Services;

namespace LiteTUI.Example.Commands
{
    public class AuthorizeCommand : CommandBase<bool>
    {
        private readonly AuthorizationService _authorizationService;
        
        public AuthorizeCommand(ApplicationContext context, AuthorizationService authorizationService) 
            : base(context)
        {
            _authorizationService = authorizationService;
        }
        
        public override async Task<bool> ExecuteAsync()
        {
            State = "Non Authorized";
            await _authorizationService.AuthorizeAsync();
            State = "Authorized";
            
            return true;
        }
    }
} 