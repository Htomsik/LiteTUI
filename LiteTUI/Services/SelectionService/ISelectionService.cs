namespace LiteTUI.Services;

public interface ISelectionService<T>
{
    public void ToggleSelection(T item);
    
    public bool IsSelected(T item, Func<T, bool>? predicate = null);
        
    public event Action? SelectionChanged;
}