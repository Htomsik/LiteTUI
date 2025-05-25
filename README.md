# LiteTUI

A simple text-based user interface library for console

## Features

### Controls
- Menu: Simple, Selection
- Input: Text Input control
- Info: Block under primary control

### Peculiarities
- "Easy-to-use" asynchronous commands with live status updates in the menu
- UI rendering updates the interface regardless of user input

## How to use

See the `LiteTUI.Example` project for a working demonstration.

```csharp
// Global App Context (Сan be inherited and create another context)
var context = new ApplicationContext();

var mainMenu = new Menu("Main Menu");
mainMenu.Items.Add(new MenuItem("Option 1", new YourCommand(context)));

// You don't have to use it if you're just close console
mainMenu.Items.Add(new MenuItem("Exit", new ExitCommand(context)));

// Main App runner, You can use any of controls instead menu
var app = new ApplicationRunner(context, mainMenu);
await app.RunAsync();
```

### Selection Menu

```csharp

var products = new List<Product> 
{
    new Product { Id = 1, Name = "Laptop", Price = 1200 },
    new Product { Id = 2, Name = "Phone", Price = 800 },
    new Product { Id = 3, Name = "Tablet", Price = 500 }
};

var selectionMenu = new MenuSelection<Product>(
    context,
    new SelectionService<Product>(products),
    "Products",
    p => $"{p.Name} - ${p.Price}",
    new ChangeControlCommand(context, mainMenu)
);
```

### Custom Control

```csharp
public class MyControl : BaseControl
{
    public MyControl(string title) : base(title) {}
    
    public override bool HandleKey(ConsoleKeyInfo keyInfo)
    {
        // Do Some with input here
        return base.HandleKey(keyInfo);
    }
    
    public override StringBuilder GetRenderContent()
    {
        var builder = new StringBuilder();
        AppendHeader(builder);
        builder.AppendLine("Your content");
        return builder;
    }
}
```

### Text Input

```csharp
// As control
var input = new TextInputControl("Enter Name");
input.InputCompleted += text => context.CurrentControl = mainMenu;

// As command
var cmd = new TextInputCommand(context, "Enter Name");
var name = await cmd.ExecuteAsync();
```

<details>
  <summary>PS</summary>

I special didn't use complex system for this. This template is only for simple applications with MINIMAL functions.

**DONT USE ANY OF THIS AS A DESIGN RECOMMENDATION**
</details>


