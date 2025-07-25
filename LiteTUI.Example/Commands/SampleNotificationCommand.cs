using LiteTUI.Commands.Base;
using LiteTUI.Controls.Info;
using LiteTUI.Core;
using LiteTUI.Services;

namespace LiteTUI.Example.Commands;

public class SampleNotificationCommand : CommandBase<bool>
{
    private readonly INotificationService _notificationService;

    public SampleNotificationCommand(ApplicationContext context, INotificationService notificationService)
        : base(context)
    {
        _notificationService = notificationService;
     
    }

    public async override Task<bool> ExecuteAsync()
    {
        Context.InfoBlock = new InfoBlock("InfoBlock", "it's not notification. It will return after notify");
        await Task.Delay(2000);
        
        await _notificationService.ShowInfo("This is an info notify");
        await Task.Delay(1000);
        
        await _notificationService.ShowError("This is an error norify");
        await Task.Delay(1000);
        
        await _notificationService.ShowCustom("CUSTOM", "This is an custom norify");
        await Task.Delay(1000);
        
        await _notificationService.Clear(true);

        return true;
    }
}