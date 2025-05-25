namespace LiteTUI.Controls.Base;


public interface IControl
{
    public string Title { get; set; }

    public bool HandleKey(ConsoleKey key);
    
    public void Render();
}