# LiteTUI

A simple text-based user interface library for console
## Features

* Simple menu navigation
* Easy-to-use asynchronous commands with live status updates in the menu
* "Customizable" information blocks for displaying additional data
* Selection menu with toggle functionality
* Independent UI rendering that updates the interface regardless of user input


## How to use

```csharp
// Context - global application state
var context = new ApplicationContext();

// Add main menu with your commands
var mainMenu = new Menu("Main Menu");
mainMenu.Items.Add(new MenuItem("Option 1", new YourCommand(context)));

// Optional
mainMenu.Items.Add(new MenuItem("Exit", new ExitCommand(context)));

// And start all of this
var application = new ApplicationRunner(context, mainMenu);
await application.RunAsync();
```

## Selection Menu

```csharp
// Example with complex objects
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

var products = new List<Product> 
{
    new Product { Id = 1, Name = "Laptop", Price = 1200 },
    new Product { Id = 2, Name = "Phone", Price = 800 },
    new Product { Id = 3, Name = "Tablet", Price = 500 }
};

var selectionService = new SelectionService<Product>(products);

// Display product with name and price
var selectionMenu = new MenuSelection<Product>(
    context,
    selectionService,
    "Select Products",
    product => $"{product.Name} - ${product.Price}",
    new ChangeControlCommand(context, mainMenu) // back command
);

// Access selections via selectionService.SelectedItems
```

## Creating a Custom Control

```csharp
// Inherit from BaseControl to create your own UI elements
public class MyCustomControl : BaseControl
{
    public MyCustomControl(string title) : base(title)
    {
    }
    
    // Override HandleKey to respond to user input
    public override bool HandleKey(ConsoleKey key)
    {
        if (key == ConsoleKey.X)
        {
            // Handle X key press
            return true;
        }
        
        return base.HandleKey(key);
    }
    
    // Override Render to define your control's appearance
    public override void Render()
    {
        RenderHeader(); // Use base header rendering
        Console.WriteLine("This is my custom control!");
    }
}
```

## Note

This package only for creating simple applications with minimal functionality. Using ApplicationContext in such a way in large and scalable applications is incorrect. You should not structure large applications like this. 