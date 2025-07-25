using System.Collections.ObjectModel;

namespace LiteTUI.Services
{
    public class SelectionService<T> : ISelectionService<T>
    {
        private  ICollection<T> _items = new List<T>();

        public ICollection<T> Items
        {
            get => _items;
            set
            {
                _items = value;
                SelectedItems.Clear();
                SelectionChanged?.Invoke();
            }
        }
        
        private HashSet<T> SelectedItems {get; set;} = new HashSet<T>();
        
        public event Action? SelectionChanged;
        
        public SelectionService(ICollection<T>? items = null)
        {
            Items = new List<T>(items ?? new List<T>());
        }
        
        public void ToggleSelection(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
            
            if (!SelectedItems.Add(item))
                SelectedItems.Remove(item);

            SelectionChanged?.Invoke();
        }

        public bool IsSelected(T item, Func<T, bool>? predicate = null ) => predicate?.Invoke(item) ?? SelectedItems.Contains(item);
    }
}