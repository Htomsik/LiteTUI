namespace LiteTUI.Services;

/// <summary>
///     Global notifications
/// </summary>
public interface INotificationService
{
    Task ShowInfo(string info); 
    
    Task ShowError(string error);

    Task ShowCustom(string title, string content);
    
    Task Clear(bool returnOrigContent = false);
}
