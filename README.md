# LiteTUI

A simple text-based user interface library for .NET console applications that provides an asynchronous menu system.

## Features

* Simple menu navigation
* Easy-to-use asynchronous commands with live status updates in the menu
* "Customizable" information blocks for displaying additional data

## How to use

See the `LiteTUI.Example` project for a working demonstration.

```csharp
// Context - global application state
var context = new ApplicationContext();

// Add main menu with your commands
var mainMenu = new Menu { Title = "Main Menu" };
mainMenu.Items.Add(new MenuItem("Option 1", new YourCommand(context)));

// Optional
mainMenu.Items.Add(new MenuItem("Exit", new ExitCommand(context)));

// And start all of this shit, you can be proud of yoursel
var application = new ApplicationRunner(context, mainMenu);
await application.RunAsync();
```
<details>
  <summary>PS</summary>

I deliberately did not use complex systems or design patterns. This template is intended only for creating simple applications with minimal functionality.

**Using ApplicationContext in such a way in large and scalable applications is incorrect. You should not structure large applications like this.**
</details>


