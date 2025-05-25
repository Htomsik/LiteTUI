using LiteTUI.Controls.Base;

namespace LiteTUI.Controls.Menu
{
    public class Menu : BaseControl
    {
        public List<MenuItem> Items { get; } = new();
        
        public int SelectedIndex { get; set; } = 0;
        
        public MenuItem? SelectedItem => Items.Count > 0 ? Items[SelectedIndex] : null;
        
        public Menu(string title) : base(title)
        {
        }
        
        protected virtual void MoveUp() => 
            SelectedIndex = Math.Max(0, SelectedIndex - 1);
        
        protected virtual void MoveDown() => 
            SelectedIndex = Math.Min(Items.Count - 1, SelectedIndex + 1);
        
        public override bool HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    return true;
                    
                case ConsoleKey.DownArrow:
                    MoveDown();
                    return true;
                    
                case ConsoleKey.Enter:
                    if (SelectedItem == null)
                        return false;
                    
                    _ = SelectedItem.ExecuteAsync();
                    return true;
                    
                default:
                    return false;
            }
        }
        
        public override void Render()
        {
            // Draw title
            RenderHeader();
            
            // Draw menu items
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                string statusText = string.Empty;
                
                // Add command status if available
                if (item.Command != null && !string.IsNullOrEmpty(item.Command.State))
                {
                    statusText = $" [{item.Command.State}]";
                }
                
                // Set color based on selection and item activity
                Console.ForegroundColor = item.IsEnabled ? ConsoleColor.Gray : ConsoleColor.DarkGray;
                
                Console.Write(i == SelectedIndex ? " > " : "   ");
                Console.WriteLine($"{item.Text}{statusText}");
                Console.ResetColor();
            }
        }
    }
} 