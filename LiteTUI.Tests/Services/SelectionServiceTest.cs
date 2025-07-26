using LiteTUI.Services;
using LiteTUI.Tests.TestData;

namespace LiteTUI.Tests.Services;

public class SelectionServiceTest
{
    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        // Arrange + Act
        var emptyService = new SelectionService<string>();
    
        var items = new List<string> { "Item1", "Item2", "Item3" };
        var serviceWithItems = new SelectionService<string>(items);
        
        // Assert
        Assert.NotNull(emptyService.Items);
        Assert.Empty(emptyService.Items);
        
        Assert.Equal(3, serviceWithItems.Items.Count);
        Assert.Contains("Item1", serviceWithItems.Items);
        Assert.Contains("Item2", serviceWithItems.Items);
        Assert.Contains("Item3", serviceWithItems.Items);
    }
    
    [Fact]
    public void ToggleSelection_WorksCorrectly()
    {
        // Arrange
        var item1 = new TestItem(){ Id = 0, Name = "Item1" };
        var item2 = new TestItem(){ Id = 1, Name = "Item2" };
        
        var eventTriggerCount = 0;

        var service = new SelectionService<TestItem>(new List<TestItem>() { item1 });
       
        service.SelectionChanged += () => eventTriggerCount++;
        
        // Act
        // Toggle existing items
        service.ToggleSelection(item1);
        service.ToggleSelection(item1);
        
        // Toggle not existing items
        service.ToggleSelection(item2);
        
        // Assert
        // items selections
        Assert.False(service.IsSelected(item1)); 
        Assert.True(service.IsSelected(item2));
        
        // items count + duplicate
        Assert.Equal(2, service.Items.Count); 
        Assert.Contains(item1, service.Items);
        Assert.Contains(item2, service.Items);
        
        // event
        Assert.Equal(3, eventTriggerCount);
    }
    
    [Fact]
    public void IsSelected_WorksCorrectly()
    {
        // Arrange
        var item1 = new TestItem { Id = 1, Name = "Item1" };
        var item2 = new TestItem { Id = 2, Name = "Item2" };
        var item3 = new TestItem { Id = 3, Name = "Item3" };
        
        var service = new SelectionService<TestItem>(new List<TestItem> { item1, item2, item3 });
        
        // Act
        service.ToggleSelection(item1);
        
        // Assert
        // direct item checks
        Assert.True(service.IsSelected(item1));
        Assert.False(service.IsSelected(item2));
        Assert.False(service.IsSelected(item3));
        
        // predicate checks
        Assert.True(service.IsSelected(item1));
        Assert.True(service.IsSelected(item1, item => item.Id == item1.Id));
        Assert.False(service.IsSelected(item2));
        Assert.False(service.IsSelected(item3, item => item.Id == item3.Id));
    }
    
    [Fact]
    public void Items_WorksCorrectly()
    {
        // Arrange
        var newItems = new List<string> { "item2", "item3" };
    
        var service = new SelectionService<string>(new List<string> { "item1" });
        service.ToggleSelection("item1"); // Select something
    
        var eventTriggered = false;
        service.SelectionChanged += () => eventTriggered = true;
    
        // Act
        service.Items = newItems;
    
        // Assert
        Assert.False(service.IsSelected("item1")); // Selection cleared
        Assert.True(eventTriggered); // Event worked
        Assert.Equal(newItems, service.Items); // Items updated
    }
}