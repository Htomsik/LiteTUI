using LiteTUI.Controls.Base;
using System.Text;

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
        
        public override bool HandleKey(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
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
        
        public override StringBuilder GetRenderContent()
        {
            var builder = new StringBuilder();
            
            // Добавляем заголовок
            AppendHeader(builder);
            
            // Добавляем пункты меню
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                string statusText = string.Empty;
                
                // Добавляем статус команды, если доступен
                if (item.Command != null && !string.IsNullOrEmpty(item.Command.State))
                {
                    statusText = $" [{item.Command.State}]";
                }
                
                // Индикатор выбранного пункта
                string selectionIndicator = i == SelectedIndex ? " > " : "   ";
                
                // Текст пункта меню (учитываем активность)
                string itemText = item.IsEnabled ? $"{item.Text}{statusText}" : $"{item.Text}{statusText}";
                
                builder.AppendLine($"{selectionIndicator}{itemText}");
            }
            
            return builder;
        }
    }
} 