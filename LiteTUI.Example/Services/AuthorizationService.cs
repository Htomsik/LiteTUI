using LiteTUI.Commands;
using LiteTUI.Commands.Base;
using LiteTUI.Core;

namespace LiteTUI.Example.Services;

public class AuthorizationService
{
    private readonly ApplicationContext _context;
    
    private readonly ITextInputCommand _textTextInputCommand;

    private string _userName = "";
    private string _password = "";
    
    public AuthorizationService(ApplicationContext context, ITextInputCommand textTextInputCommand)
    {
        _context = context;
        _textTextInputCommand = textTextInputCommand;
    }
    
    public async Task AuthorizeAsync()
    {
        // Use getData method to request necessary data
        _userName = await GetData("Username");
        _password = await GetData("Password");
    }
    
    // Method for requesting input data
    private async Task<string> GetData(string what)
    {
        // Create and execute command
        _textTextInputCommand.Title = what;
        return await _textTextInputCommand.ExecuteAsync();
    }
}