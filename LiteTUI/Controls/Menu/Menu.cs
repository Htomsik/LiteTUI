namespace LiteTUI.Controls.Menu
{
    public class Menu(string title)
    {
        public string Title { get; set; } = title;
        
        public List<MenuItem> Items { get; } = new();
        
        public int SelectedIndex { get; set; } = 0;
        
        public MenuItem? SelectedItem => Items.Count > 0 ? Items[SelectedIndex] : null;
        
        public void MoveUp() => 
            SelectedIndex = Math.Max(0, SelectedIndex - 1);
        
        public void MoveDown() => 
            SelectedIndex = Math.Min(Items.Count - 1, SelectedIndex + 1);
    }
} 