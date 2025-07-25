namespace LiteTUI.Services;

public interface ISelectionService<T>
{
    /// <summary>
    ///     Original elements 
    /// </summary>
    public ICollection<T> Items { get; set; }
    
    /// <summary>
    ///     Add/Remove items to selection
    /// </summary>
    public void ToggleSelection(T item);
    
    /// <summary>
    ///     Check is item in selection
    /// </summary>
    public bool IsSelected(T item, Func<T, bool>? predicate = null);
        
    /// <summary>
    ///     Execution then election changed
    /// </summary>
    public event Action? SelectionChanged;
}