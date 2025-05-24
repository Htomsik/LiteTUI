namespace LiteTUI.Services;

public interface ISelectionService<T>
{
    public void ToggleSelection(T item);
        
    public bool IsSelected(T item);
        
    public event Action? SelectionChanged;
}