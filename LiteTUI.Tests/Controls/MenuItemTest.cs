using LiteTUI.Commands.Base;
using LiteTUI.Controls.Menu;
using LiteTUI.Tests.TestData;

namespace LiteTUI.Tests.Controls;

public class MenuItemTest
{
    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        // Arrange + Act
        var command = new TestCommand();
        var menuItem = new MenuItem("Item1", command);
        
        // Assert
        Assert.Equal("Item1", menuItem.Text);
        Assert.Equal(command, menuItem.Command);
        Assert.True(menuItem.IsEnabled);
    }
    
    [Fact]
    public async Task ExecuteAsync_WorksCorrectly()
    {
        // Arrange
        var enabledCommand = new TestCommand();
        var disabledCommand = new TestCommand();
        
        var enabledItem = new MenuItem("Enabled", enabledCommand);
        var disabledItem = new MenuItem("Disabled", disabledCommand) { IsEnabled = false };
        
        // Act
        await enabledItem.ExecuteAsync();
        await disabledItem.ExecuteAsync();
        
        // Assert
        // enabled item executes
        Assert.True(enabledCommand.WasExecuted);
        
        // disabled item does not execute
        Assert.False(disabledCommand.WasExecuted);
    }
    
}