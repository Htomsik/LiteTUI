using LiteTUI.Commands.Base;
using LiteTUI.Controls.Input;
using LiteTUI.Core;

namespace LiteTUI.Commands;

public class TextInputCommand : CommandBase<string>, ITextInputCommand
{
    public string Title { get; set; } = string.Empty;
    
    private TaskCompletionSource<string> _taskCompletionSource;

    public TextInputCommand(ApplicationContext context)
        : base(context)
    { }
    
    public override async Task<string> ExecuteAsync()
    {
        var result = "";
        _taskCompletionSource = new TaskCompletionSource<string>();
        
        var previousControl = Context.CurrentControl;
        
        var textInput = new TextInputControl(Title);
        textInput.InputCompleted += input =>
        {
            result = input;
            _taskCompletionSource.SetResult(input);
        };
        Context.CurrentControl = textInput;
        
        await _taskCompletionSource.Task;
        
        Context.CurrentControl = previousControl;
        
        return result;
    }

    
} 