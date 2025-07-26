using LiteTUI.Controls.Menu;
using LiteTUI.Commands.Base;
using LiteTUI.Tests.TestData;

namespace LiteTUI.Tests.Controls;

public class MenuTest
{
    // Helper
    private static Menu CreateMenuWithItems(int count)
    {
        var menu = new Menu("Test");
        for (int i = 1; i <= count; i++)
        {
            menu.Items.Add(new MenuItem($"Item{i}", new TestCommand()));
        }
        return menu;
    }
    
    private static bool PressKey(Menu menu, ConsoleKey key)
    {
        return menu.HandleKey(new ConsoleKeyInfo(' ', key, false, false, false));
    }
    
    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        // Arrange + Act
        var menu = new Menu("Test Menu");
        
        // Assert
        Assert.Equal("Test Menu", menu.Title);
        Assert.NotNull(menu.Items);
        Assert.Empty(menu.Items);
        Assert.Equal(0, menu.SelectedIndex);
        Assert.Null(menu.SelectedItem);
    }
    
    [Fact]
    public void Navigation_WorksCorrectly()
    {
        // Arrange
        var menu = CreateMenuWithItems(3);
        
        // Act + Assert
        // Check what index at first element on start
        Assert.Equal(0, menu.SelectedIndex);
        
        // Navigate down 
        menu.SelectedIndex = 0;
        PressKey(menu, ConsoleKey.DownArrow);
        Assert.Equal(1, menu.SelectedIndex);
        
        // Navigate up 
        menu.SelectedIndex = 1;
        PressKey(menu, ConsoleKey.UpArrow);
        Assert.Equal(0, menu.SelectedIndex);
        
        // Try to go beyond last item
        menu.SelectedIndex = 2;
        PressKey(menu, ConsoleKey.DownArrow);
        Assert.Equal(2, menu.SelectedIndex); // stays at last
        
        // Try to go beyond first item
        menu.SelectedIndex = 0;
        PressKey(menu, ConsoleKey.UpArrow);
        Assert.Equal(0, menu.SelectedIndex); // stays at first
        
        // item is correctly
        menu.SelectedIndex = 0;
        Assert.Equal("Item1", menu.SelectedItem?.Text);
        
        PressKey(menu, ConsoleKey.DownArrow);
        Assert.Equal("Item2", menu.SelectedItem?.Text);
        
        PressKey(menu, ConsoleKey.DownArrow);
        Assert.Equal("Item3", menu.SelectedItem?.Text);
    }
    
    [Fact]
    public void HandleKey_WorksCorrectly()
    {
        // Arrange
        var emptyMenu = new Menu("Empty");
        
        var command = new TestCommand();
        var menu = new Menu("Test");
        menu.Items.Add(new MenuItem("Item1", command));
        
        // Act + Assert
        Assert.True(PressKey(menu, ConsoleKey.UpArrow));
        Assert.True(PressKey(menu, ConsoleKey.DownArrow));
        Assert.True(PressKey(menu, ConsoleKey.Enter));
        Assert.True(command.WasExecuted);
        
        Assert.False(PressKey(menu, ConsoleKey.A));
        Assert.False(PressKey(emptyMenu, ConsoleKey.Enter));
    }
}