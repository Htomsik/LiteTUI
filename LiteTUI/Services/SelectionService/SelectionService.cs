namespace LiteTUI.Services
{
    public class SelectionService<T>(ICollection<T> items) : ISelectionService<T>
    {
        public readonly HashSet<T> SelectedItems = new();
        public readonly ICollection<T> Items = items;
        public event Action? SelectionChanged;
        
        public void ToggleSelection(T item)
        {
            if (!SelectedItems.Add(item))
                SelectedItems.Remove(item);

            SelectionChanged?.Invoke();
        }

        public bool IsSelected(T item, Func<T, bool>? predicate = null ) => predicate?.Invoke(item) ?? SelectedItems.Contains(item);
    }
}