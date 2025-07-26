using LiteTUI.Controls.Info;
using LiteTUI.Core;
using LiteTUI.Services;

namespace LiteTUI.Tests.Services;

public class NotificationServiceTest
{
    // Helper 
    private static ApplicationContext CreateContext(InfoBlock? infoBlock = null)
    {
        var context = new ApplicationContext();

        if (infoBlock != null)
        {
            context.InfoBlock = infoBlock;
        }
        
        return context;
    }
    
    private static NotificationService CreateService(ApplicationContext? context = null)
    {
        return new NotificationService(context ?? CreateContext());
    }
    
    private static void AssertNotification(ApplicationContext context, string content, NotificationType type)
    {
        Assert.IsType<NotificationBlock>(context.InfoBlock);
        var notification = (NotificationBlock)context.InfoBlock;
        Assert.Equal(content, notification.Content);
        Assert.Equal(type, notification.Type);
    }
    
    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        // Arrange + Act
        var context = CreateContext();
        var service = CreateService(context);
        
        // Assert
        Assert.NotNull(service);
    }
    
    [Fact]
    public async Task Show_AllMethods_WorkCorrectly()
    {
        // Arrange
        var context = CreateContext();
        var service = CreateService(context);
        
        // Act + Assert
        // ShowInfo
        await service.ShowInfo("info");
        AssertNotification(context, "info", NotificationType.Info);
        
        // ShowError  
        await service.ShowError("error");
        AssertNotification(context, "error", NotificationType.Error);
        
        // ShowCustom
        await service.ShowCustom("Custom", "content");
        AssertNotification(context, "content", NotificationType.Info);
        
        // Validation - empty/null ignored
        var lastNotification = context.InfoBlock;
        await service.ShowInfo("");
        await service.ShowError("");  
        await service.ShowCustom("", "content");
        await service.ShowCustom("title", "");
        
        Assert.Equal(lastNotification, context.InfoBlock);
    }
    
    [Fact]
    public async Task OriginalInfoBlock_SaveAndRestore_WorksCorrectly()
    {
        // Arrange
        var originalInfoBlock = new InfoBlock("Original", "Original content");
        var context = CreateContext(originalInfoBlock);
        var originalBlock = context.InfoBlock;
        var service = CreateService(context);
        
        // Act
        await service.ShowError("Error");
        await service.ShowInfo("Info");
        await service.ShowCustom("Custom", "Custom");
        await  service.Clear();
        
        // Assert
        Assert.Equal(originalBlock, context.InfoBlock);
    }
    
    [Fact]
    public async Task NotificationBlock_DoesNotSaveAsOriginal()
    {
        // Arrange
        var context = CreateContext();
        var service = CreateService(context);
        
        // Act + Assert
        // First notification
        await service.ShowInfo("First");
        var firstNotification = context.InfoBlock;
        
        // Second notification should not save first notification as original
        await service.ShowError("Second");
        Assert.IsType<NotificationBlock>(context.InfoBlock);
        Assert.Equal("ERROR", ((NotificationBlock)context.InfoBlock).Title);
        
        // Clear should restore to null (no original)
        await service.Clear();
        Assert.Null(context.InfoBlock);
    }
}