using LiteTUI.Commands.Base;

namespace LiteTUI.Tests.TestData;

internal class TestCommand : ICommand
{
    public string State { get; set; } = string.Empty;
    
    public bool WasExecuted { get; private set; }
        
    public Task ExecuteAsync()
    {
        WasExecuted = true;
        return Task.CompletedTask;
    }
}