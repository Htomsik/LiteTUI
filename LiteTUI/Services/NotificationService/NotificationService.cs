using LiteTUI.Attributes;
using LiteTUI.Controls.Base;
using LiteTUI.Controls.Info;
using LiteTUI.Core;

namespace LiteTUI.Services;


public class NotificationService(ApplicationContext appContext) : INotificationService
{
    /// <summary>
    ///     Saved original info
    /// </summary>
    [AsyncLock]
    private IControl? OriginalInfoBlock {get; set;}
    
    /// <summary>
    ///     Global application context
    /// </summary>
    private readonly ApplicationContext _appContext = appContext;

    public async Task ShowInfo(string info)
    {
        if (string.IsNullOrWhiteSpace(info))
            return;
        
        await SaveOriginal();
        _appContext.InfoBlock = new NotificationBlock("INFO", info, NotificationType.Info);
    }

    public async Task ShowError(string error)
    {
        if (string.IsNullOrEmpty(error))
            return;
        
        await SaveOriginal();
        _appContext.InfoBlock = new NotificationBlock("ERROR", error, NotificationType.Error);
    }

    public async Task ShowCustom(string title, string content)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(content))
            return;
        
        await SaveOriginal();
        _appContext.InfoBlock = new NotificationBlock(title, content, NotificationType.Info);
    }

    public async Task Clear(bool returnOrigContent = false)
    {
        await RestoreOriginal();
    }

    private Task SaveOriginal()
    {
        // Notifications and infoBlock not same type
        if (_appContext.InfoBlock?.GetType() == typeof(NotificationBlock))
            return Task.CompletedTask;
        
        OriginalInfoBlock = _appContext.InfoBlock;
        
        return Task.CompletedTask;
    }

    private Task RestoreOriginal()
    {
        // If in context infoblock probably changed to other than not change
        if (_appContext.InfoBlock?.GetType() == typeof(NotificationBlock))
        {
            _appContext.InfoBlock = OriginalInfoBlock;
        }
        
        OriginalInfoBlock = null;
        
        return Task.CompletedTask;
    }
}